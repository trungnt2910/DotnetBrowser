using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Trungnt2910.Browser.JsInterop;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal static class RoslynFactory
{
    private const string PROP_PREFIX = "prop_";

    public static GeneratedMember? Create(GeneratorSyntaxContext context)
    {
        if (context.Node is not AttributeListSyntax attributeList)
        {
            return null;
        }

        var jsImportAttributeSyntax = attributeList.Attributes.SingleOrDefault(a => a.Name.IsAttribute(nameof(JsImportAttribute)));

        if (jsImportAttributeSyntax == null)
        {
            return null;
        }

        GeneratedMember result;
        var diagnostics = new List<Diagnostic>();

        var semanticModel = context.SemanticModel;

        if (context.Node.Parent is MethodDeclarationSyntax methodDeclaration)
        {
            var methodName = methodDeclaration.Identifier.ValueText;

            var returnType = semanticModel.GetTypeInfo(methodDeclaration.ReturnType);
            var containingType = semanticModel.GetDeclaredSymbol(methodDeclaration)?.ContainingSymbol as ITypeSymbol;
            var parameters = methodDeclaration.ParameterList.Parameters.Select(p => semanticModel.GetTypeInfo(p.Type!)).ToList();
            var parameterNames = methodDeclaration.ParameterList.Parameters.Select(p => p.Identifier.ValueText).ToList();
            var isLastParameterParams = methodDeclaration.ParameterList.Parameters.LastOrDefault()?
                .Modifiers.Any(t => t.IsKind(SyntaxKind.ParamsKeyword)) ?? false;
            var typeParameters = methodDeclaration.TypeParameterList?.Parameters.Select(p => p.Identifier.ValueText).ToList();
            var typeConstraints = methodDeclaration.ConstraintClauses.ToDictionary(
                c => c.Name.Identifier.ValueText,
                c => c.Constraints.OfType<TypeConstraintSyntax>().Select(tc => GetTypeInfo(semanticModel.GetTypeInfo(tc.Type).Type)!).ToList());

            var virtualOverrideSealedNew = "";
            if (methodDeclaration.DescendantTokens().Any(t => t.IsKind(SyntaxKind.VirtualKeyword)))
            {
                virtualOverrideSealedNew = "virtual";
            }
            if (methodDeclaration.DescendantTokens().Any(t => t.IsKind(SyntaxKind.OverrideKeyword)))
            {
                virtualOverrideSealedNew = "override";
            }
            if (methodDeclaration.DescendantTokens().Any(t => t.IsKind(SyntaxKind.SealedKeyword)))
            {
                virtualOverrideSealedNew = "sealed";
            }
            if (methodDeclaration.DescendantTokens().Any(t => t.IsKind(SyntaxKind.NewKeyword)))
            {
                virtualOverrideSealedNew = "new";
            }

            var unsupportedConstraintsExists = methodDeclaration.ConstraintClauses.Any(tc =>
            {
                return tc.Constraints.Any(c =>
                {
                    if (c is not TypeConstraintSyntax typeConstraintSyntax)
                    {
                        return true;
                    }
                    var constraintType = semanticModel.GetTypeInfo(typeConstraintSyntax.Type).Type;
                    if (constraintType == null)
                    {
                        return true;
                    }
                    if (constraintType.TypeKind == TypeKind.TypeParameter)
                    {
                        return false;
                    }
                    if (constraintType.IsJsObject())
                    {
                        return false;
                    }
                    return true;
                });
            });

            if (unsupportedConstraintsExists)
            {
                diagnostics.Add(Diagnostic.Create(Descriptors.UnsupportedConstraintClauses,
                    context.Node.Parent.GetLocation()));
            }

            // These are actually properties.
            if (methodName.StartsWith(PROP_PREFIX))
            {
                if (parameters.Count != 1)
                {
                    diagnostics.Add(Diagnostic.Create(Descriptors.InvalidPropertyImport,
                        context.Node.Parent.GetLocation(),
                        "Property import placeholders should take at least one parameter."));
                }
                result = new GeneratedProperty()
                {
                    Name = methodName.Substring(PROP_PREFIX.Length),
                    Type = GetTypeInfo(parameters[0].Type),
                    ClassType = GetTypeInfo(containingType)
                };
            }
            else
            {
                result = new GeneratedMethod()
                {
                    Name = methodName,
                    Parameters = parameters.Select(p => GetTypeInfo(p.Type)!).ToList(),
                    ParameterNames = parameterNames,
                    IsLastParameterParams = isLastParameterParams,
                    Type = GetTypeInfo(returnType.Type),
                    ClassType = GetTypeInfo(containingType),
                    TypeParameters = typeParameters,
                    TypeConstraints = typeConstraints,
                    VirtualOverrideSealedNew = virtualOverrideSealedNew
                };
            }
        }
        else if (context.Node.Parent is ClassDeclarationSyntax classDeclaration)
        {
            var className = classDeclaration.Identifier.ValueText;

            var typeParameters = classDeclaration.TypeParameterList?.Parameters.Select(p => p.Identifier.ValueText).ToList();
            var typeConstraints = classDeclaration.ConstraintClauses.ToDictionary(
                c => c.Name.Identifier.ValueText,
                c => c.Constraints.OfType<TypeConstraintSyntax>().Select(tc => GetTypeInfo(semanticModel.GetTypeInfo(tc.Type).Type)!).ToList());

            var classType = semanticModel.GetDeclaredSymbol(classDeclaration) as ITypeSymbol;

            if (classType?.BaseType?.SpecialType != SpecialType.System_Object
                && !(classType?.IsJsObject() ?? false))
            {
                diagnostics.Add(Diagnostic.Create(Descriptors.InvalidClassImport, context.Node.Parent.GetLocation(),
                    $"Base class '{classType?.BaseType?.Name}' is not a subclass of JsObject."));
            }

            result = new GeneratedClass()
            {
                Name = null,
                ClassType = GetTypeInfo(classType),
                TypeParameters = typeParameters,
                TypeConstraints = typeConstraints,
            };
        }
        else
        {
            return null;
        }

        result.JsImportAttribute = ExtractAttribute(jsImportAttributeSyntax, semanticModel);
        result.Diagnostics = diagnostics;

        return result;
    }

    private static JsImportAttribute ExtractAttribute(AttributeSyntax syntax, SemanticModel semanticModel)
    {
        var attribute = new JsImportAttribute();

        if (syntax.ArgumentList != null)
        {
            foreach (var argumentSyntax in syntax.ArgumentList.Arguments)
            {
                var name = argumentSyntax.NameEquals?.Name.ToString();
                var value = semanticModel.GetConstantValue(argumentSyntax.Expression);

                if (!value.HasValue)
                {
                    continue;
                }

                var prop = typeof(JsImportAttribute).GetType().GetProperty(name);
                prop?.SetValue(attribute, value.Value);
            }
        }

        return attribute;
    }

    private static Dictionary<ITypeSymbol, TypeInfo> _cache = new(SymbolEqualityComparer.Default);
    private static TypeInfo? GetTypeInfo(ITypeSymbol? typeSymbol)
    {
        if (typeSymbol == null)
        {
            return null;
        }

        if (_cache.ContainsKey(typeSymbol))
        {
            return _cache[typeSymbol];
        }

        var result = new TypeInfo();
        _cache.Add(typeSymbol, result);

        if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol)
        {
            result.Name = "";
            result.NamespaceName = "";
            result.ElementType = GetTypeInfo(arrayTypeSymbol.ElementType);
        }
        else
        {
            result.Name = typeSymbol.Name;
            result.NamespaceName = typeSymbol.GetContainingNamespaceName(true);
        }

        if (result.NamespaceName.StartsWith("global::"))
        {
            result.NamespaceName = result.NamespaceName.Substring("global::".Length);
        }
        result.NamespaceName = result.NamespaceName.TrimEnd('.');
        result.BaseType = GetTypeInfo(typeSymbol.BaseType);
        result.Interfaces = typeSymbol.Interfaces.Select(ts => GetTypeInfo(ts)!).ToList();

        if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
        {
            result.TypeArguments = namedTypeSymbol.TypeArguments.Select(ts => GetTypeInfo(ts)!).ToList();
        }

        result.IsInterface = typeSymbol.TypeKind == TypeKind.Interface;
        result.IsTemplateParameter = typeSymbol.TypeKind == TypeKind.TypeParameter;
        result.IsArray = typeSymbol.TypeKind == TypeKind.Array;
        result.SpecialType = typeSymbol.SpecialType;
        return result;
    }
}

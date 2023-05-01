using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text.RegularExpressions;
using Trungnt2910.Browser.Generators.TypeScript.Models;
using Trungnt2910.Browser.Generators.TypeScript.Utilities;
using Zu.TypeScript;
using Zu.TypeScript.TsTypes;
using Diagnostic = Microsoft.CodeAnalysis.Diagnostic;
using TextSpan = Microsoft.CodeAnalysis.Text.TextSpan;

namespace Trungnt2910.Browser.Generators.TypeScript.Factories;

/// <summary>
/// Fully managed factory based on an ancient library.
/// </summary>
internal static class TypeScriptAstFactory
{
    private static Documentation CreateDocumentation(INode nodeInterface, Action<int, int, string>? log = null)
    {
        var doc = new Documentation();

        if (nodeInterface is Node node)
        {
            var commentRangeStart = node.Pos;
            var commentRangeEnd = node.NodeStart;

            if (commentRangeStart != null)
            {
                var commentStrings = (IEnumerable<string>)node.SourceStr.Substring(commentRangeStart.Value, commentRangeEnd - commentRangeStart.Value)
                    .Replace("\r\n", "\n").Trim().Split('\n');

                commentStrings = commentStrings.Reverse().TakeWhile(s => !string.IsNullOrEmpty(s)).Reverse()
                    .Select(s => s.Trim().Trim(new[] { '*', '/' }).Trim())
                    .Where(s => !string.IsNullOrEmpty(s));

                var nonTagged = new List<string>();

                foreach (var commentString in commentStrings)
                {
                    if (commentString.StartsWith("@"))
                    {
                        var firstWord = new string(commentString.Skip(1).TakeWhile(ch => !char.IsWhiteSpace(ch)).ToArray());
                        var contents = commentString.Substring(1 + firstWord.Length).Trim();
                        switch (firstWord)
                        {
                            case "deprecated":
                                doc.IsDeprecated = true;
                                if (!string.IsNullOrEmpty(contents))
                                {
                                    if (doc.DeprecatedText != null)
                                    {
                                        doc.DeprecatedText += Environment.NewLine + contents;
                                    }
                                    else
                                    {
                                        doc.DeprecatedText = contents;
                                    }
                                }
                                break;
                            case "param":
                                {
                                    var paramName = new string(contents.TakeWhile(ch => !char.IsWhiteSpace(ch)).ToArray());
                                    doc.ParamComments.Add(paramName, contents.Substring(paramName.Length).Trim().ToXmlDocString());
                                }
                                break;
                            default:
                                log?.Invoke(commentRangeStart.GetValueOrDefault(), commentRangeEnd, "Unsupported JsDoc tag: {firstWord}");
                                nonTagged.Add(commentString);
                                break;
                        }
                    }
                    else
                    {
                        doc.Comments.Add(commentString.ToXmlDocString());
                    }
                }

                doc.DeprecatedText = doc.DeprecatedText?.ToCommentAttributeLiteral();
            }
        }

        return doc;
    }

    private static Event CreateEvent(PropertySignature property, Action<int, int, string>? log = null)
    {
        var ev = new Event();

        ev.Name = ((StringLiteral)property.Children[0]).Text;
        ev.Type = CreateTsType((TypeReferenceNode)property.Children[1], log);
        ev.Documentation = CreateDocumentation(property);

        return ev;
    }

    private static EventMap CreateEventMap(InterfaceDeclaration declaration, Action<int, int, string>? log = null)
    {
        var evMap = new EventMap();

        evMap.Name = declaration.IdentifierStr;
        evMap.Documentation = CreateDocumentation(declaration);

        if (declaration.TypeParameters?.Any() ?? false)
        {
            System.Diagnostics.Debugger.Break();
        }

        var extendList = declaration.HeritageClauses?.FirstOrDefault()?.Children;
        if (extendList?.Any() ?? false)
        {
            evMap.BaseTypes = extendList.Select(t => CreateTsType((ITypeNode)t, log)).ToList();
        }

        foreach (var member in declaration.Members)
        {
            if (member is PropertySignature property &&
                member.Children.Count == 2 &&
                member.Children[0].Kind == SyntaxKind.StringLiteral &&
                member.Children[1].Kind == SyntaxKind.TypeReference)
            {
                var ev = CreateEvent(property);
                ev.Documentation.IsDeprecated = evMap.Documentation.IsDeprecated || ev.Documentation.IsDeprecated;
                evMap.Events.Add(ev);
            }
            else
            {
                log?.Invoke(member.Pos.GetValueOrDefault(), member.End.GetValueOrDefault(), $"Member {member.GetText()} not recognized in a event map.");
            }
        }

        return evMap;
    }

    private static Indexer CreateIndexer(IndexSignatureDeclaration declaration, Action<int, int, string>? log = null)
    {
        var indexer = new Indexer();

        indexer.Documentation = CreateDocumentation(declaration);
        indexer.Type = CreateTsType(declaration.Type, log);
        indexer.IsReadOnly = declaration.OfKind(SyntaxKind.ReadonlyKeyword).Any();
        indexer.Parameters = declaration.Parameters.Select(p => CreateTsType(p.Type, log)).ToList();
        indexer.ParameterNames = declaration.Parameters.Select(p => ((Identifier)p.Name).IdentifierStr).ToList();

        return indexer;
    }

    private static Interface CreateInterface(TypeLiteralNode declaration, Action<int, int, string>? log = null)
    {
        var iface = new Interface();

        iface.AddMembers(declaration, declaration.Members, log);
        iface.Documentation = CreateDocumentation(declaration);
        iface.Documentation.AppendCommentLine($"Generated from inline type: <c>{declaration.GetText()}</c>.");
        var nameElements = string.Join("And", iface.Methods.Select(m => m.Name.ToCSharpElementName())
            .Concat(iface.Properties.Select(p => p.Name.ToCSharpElementName())));
        iface.Name = $"InlineHas{nameElements}";

        return iface;
    }

    private static Interface CreateInterface(InterfaceDeclaration declaration, Action<int, int, string>? log = null)
    {
        var iface = new Interface();

        iface.Name = declaration.IdentifierStr;
        iface.Documentation = CreateDocumentation(declaration);

        // Special case for these interfaces. They are not real
        // objects, they only signal that the implementer has a member
        // with the same name.
        if (new[] { "Body", "InnerHTML" }.Contains(iface.Name))
        {
            iface.Name = "Has" + iface.Name;
        }

        if (declaration.TypeParameters?.Any() ?? false)
        {
            iface.TypeParameters = declaration.TypeParameters.Select(typeParamDecl => typeParamDecl.Children[0].IdentifierStr).ToList();
            iface.TypeParameterDefaults = declaration.TypeParameters
                .Select(typeParamDecl => typeParamDecl.Children.Count <= 1 ? null : CreateTsType((ITypeNode)typeParamDecl.Children[1], log))
                .ToList();
        }

        var extendList = declaration.HeritageClauses?.FirstOrDefault()?.Children;
        if (extendList?.Any() ?? false)
        {
            iface.BaseTypes = extendList.Select(t => CreateTsType((ITypeNode)t, log)).ToList();
        }

        iface.AddMembers(declaration, declaration.Members, log);

        if (iface.Properties.Where(p => p.Name == "length" && p.Type.Name == "number").Any())
        {
            iface.ReadOnlyListElementType = iface.Indexers.Where(i => i.Parameters.Count == 1 && i.Parameters[0].Name == "number").FirstOrDefault()?.Type;
        }

        return iface;
    }

    private static void AddMembers(this Interface iface, ITextRange declaration, IEnumerable<ITypeElement> members, Action<int, int, string>? log = null)
    {
        foreach (var member in members)
        {
            switch (member)
            {
                case PropertySignature propertyDeclaration:
                    iface.Properties.Add(CreateProperty(propertyDeclaration, log));
                    break;
                case MethodSignature methodDeclaration:
                    // Blacklisted methods due to heavy indexed access type usage.
                    if (!methodDeclaration.GetText().Contains("extends keyof"))
                    {
                        iface.Methods.Add(CreateMethod(methodDeclaration, log));
                    }
                    else if (methodDeclaration.IdentifierStr == "addEventListener")
                    {
                        iface.EventMapType = CreateTsType(methodDeclaration
                            .Children.OfType<TypeParameterDeclaration>().Single()
                            .Children.OfType<TypeOperatorNode>().Where(n => n.Operator == SyntaxKind.KeyOfKeyword).Single()
                            .Children.OfType<TypeReferenceNode>().Single(), log);
                    }
                    else
                    {
                        log?.Invoke(methodDeclaration.Pos.GetValueOrDefault(), methodDeclaration.End.GetValueOrDefault(), "Method contains unsupported 'extends keyof' in its declaration.");
                    }
                    break;
                case IndexSignatureDeclaration indexDeclaration:
                    iface.Indexers.Add(CreateIndexer(indexDeclaration, log));
                    break;
                case CallSignatureDeclaration callDeclaration:
                    iface.CallSignatures.Add(CreateMethod(callDeclaration, log));
                    break;
                case ConstructSignatureDeclaration constructSignatureDeclaration:
                    log?.Invoke(declaration.Pos.GetValueOrDefault(), declaration.End.GetValueOrDefault(), $"Construct signatures {constructSignatureDeclaration.GetText()} are not supported.");
                    break;
                default:
                    System.Diagnostics.Debugger.Break();
                    break;
            }
        }
    }

    private static Method CreateMethod(ISignatureDeclaration method, Action<int, int, string>? log = null)
    {
        var tsMethod = new Method();

        tsMethod.Name = method.Name.GetText();
        tsMethod.Documentation = CreateDocumentation(method);

        tsMethod.ReturnType = CreateTsType(method.Type, log);
        tsMethod.Parameters = method.Parameters.Select(p =>
        {
            var type = CreateTsType(p.Type, log);
            if (p.QuestionToken != null)
            {
                type.IsNullable = true;
            }
            return type;
        }).ToList();
        tsMethod.ParameterNames = method.Parameters.Select(p => ((Identifier)p.Name).IdentifierStr).ToList();
        tsMethod.IsLastParameterParams = method.Parameters.LastOrDefault()?.Children.OfType<DotDotDotToken>().Any() ?? false;

        if (method.TypeParameters?.Any() ?? false)
        {
            tsMethod.TypeParameters = method.TypeParameters.Select(typeParamDecl => typeParamDecl.Children[0].IdentifierStr).ToList();
            foreach (var t in method.TypeParameters)
            {
                TsType? constraintType = null;
                TsType? defaultType = null;
                switch (t.Children.Count)
                {
                    case 2:
                        // T extends JsObject OR T = JsObject
                        if (method.GetText().Contains("extends"))
                        {
                            constraintType = CreateTsType((ITypeNode)t.Children[1], log);
                        }
                        else if (method.GetText().Contains('='))
                        {
                            defaultType = CreateTsType((ITypeNode)t.Children[1], log);
                        }
                        break;
                    case 3:
                        // T extends JsObject = JsObject
                        constraintType = CreateTsType((ITypeNode)t.Children[1], log);
                        defaultType = CreateTsType((ITypeNode)t.Children[1], log);
                        break;
                    case 1:
                    default:
                        break;
                }
                tsMethod.TypeParameterConstraints.Add(constraintType);
                tsMethod.TypeParameterDefaults.Add(defaultType);
            }
        }

        return tsMethod;
    }

    private static Method CreateMethod(CallSignatureDeclaration callSignature, Action<int, int, string>? log = null)
    {
        var tsMethod = new Method();

        tsMethod.Name = "Invoke";
        tsMethod.Documentation = CreateDocumentation(callSignature);

        tsMethod.ReturnType = CreateTsType(callSignature.Type, log);
        tsMethod.Parameters = callSignature.Parameters.Select(p =>
        {
            var type = CreateTsType(p.Type, log);
            if (p.QuestionToken != null)
            {
                type.IsNullable = true;
            }
            return type;
        }).ToList();
        tsMethod.ParameterNames = callSignature.Parameters.Select(p => ((Identifier)p.Name).IdentifierStr).ToList();

        if (callSignature.TypeParameters?.Any() ?? false)
        {
            tsMethod.TypeParameters = callSignature.TypeParameters.Select(typeParamDecl => typeParamDecl.Children[0].IdentifierStr).ToList();
            tsMethod.TypeParameterDefaults = callSignature.TypeParameters
                .Select(typeParamDecl => (typeParamDecl.Children.Count <= 1 || !typeParamDecl.Children.OfKind(SyntaxKind.EqualsToken).Any()) ? null : CreateTsType((ITypeNode)typeParamDecl.Children[1], log))
                .ToList();
        }

        return tsMethod;
    }

    private static Property CreateProperty(IVariableLikeDeclaration declaration, Action<int, int, string>? log = null)
    {
        var tsProperty = new Property();
        tsProperty.Name = declaration.Name.GetText();
        tsProperty.Documentation = CreateDocumentation(declaration);
        tsProperty.Type = CreateTsType(declaration.Type, log);
        if ((declaration as Node)?.OfKind(SyntaxKind.ReadonlyKeyword).Any() ?? false)
        {
            tsProperty.IsReadOnly = true;
        }
        if ((declaration as Node)?.OfKind(SyntaxKind.ConstKeyword).Any() ?? false)
        {
            tsProperty.IsReadOnly = true;
        }
        if ((declaration as Node)?.OfKind(SyntaxKind.QuestionToken).Any() ?? false)
        {
            tsProperty.IsNullable = true;
        }
        return tsProperty;
    }

    private static TsType CreateTsType(ITypeNode type, Action<int, int, string>? log = null)
    {
        var tsType = new TsType();

        if ((type.Modifiers?.Count ?? 0) > 0)
        {
            System.Diagnostics.Debugger.Break();
        }

        switch (type.Kind)
        {
            case SyntaxKind.BooleanKeyword:
                tsType.Name = "boolean";
                break;
            case SyntaxKind.NumberKeyword:
                tsType.Name = "number";
                break;
            case SyntaxKind.StringKeyword:
                tsType.Name = "string";
                break;
            case SyntaxKind.NullKeyword:
                tsType.Name = "null";
                break;
            case SyntaxKind.UndefinedKeyword:
                tsType.Name = "undefined";
                break;
            case SyntaxKind.VoidKeyword:
                tsType.Name = "void";
                break;
            case SyntaxKind.AnyKeyword:
                tsType.Name = "any";
                tsType.IsNullable = true;
                break;
            case SyntaxKind.TypeReference:
                {
                    var typeReference = (TypeReferenceNode)type;
                    if ((typeReference.TypeArguments?.Count ?? 0) > 0)
                    {
                        tsType.TypeParameters = typeReference.TypeArguments!.Select(t => CreateTsType(t, log)).ToList();
                    }
                    if (type.Children.Count == 1 + tsType.TypeParameters.Count && type.Children[0] is Identifier)
                    {
                        tsType.Name = type.Children[0].IdentifierStr;
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
                break;
            case SyntaxKind.UnionType:
                {
                    var unionType = (UnionTypeNode)type;

                    var memberTypes = unionType.Types.Select(t => CreateTsType(t, log));
                    var nullTypeCount = memberTypes.Where(t => t.Name == "null" || t.Name == "undefined").Count();
                    var nonNullTypes = memberTypes.Where(t => t.Name != "null" && t.Name != "undefined").ToList();
                    if (nullTypeCount == unionType.Count - 1)
                    {
                        tsType.AssignToThis(nonNullTypes[0]);
                    }
                    // Union of the same kind.
                    else if (nonNullTypes.FirstOrDefault(nnT => nnT != nonNullTypes[0]) == null)
                    {
                        tsType.AssignToThis(nonNullTypes[0]);
                    }
                    else if (nonNullTypes.Count == nonNullTypes.Where(nnT => nnT.Kind == TsTypeKind.StringList).Count())
                    {
                        tsType.AssignToThis(nonNullTypes[0]);
                        tsType.Kind = TsTypeKind.Normal;
                        tsType.Name = "string";
                    }
                    else
                    {
                        tsType.Kind = TsTypeKind.Union;
                        void DFS(TsType type)
                        {
                            if (type.Kind != TsTypeKind.Union)
                            {
                                tsType.MemberTypes.Add(type);
                            }
                            else
                            {
                                foreach (var subtype in type.MemberTypes)
                                {
                                    DFS(subtype);
                                }
                            }
                        }
                        foreach (var nnt in nonNullTypes)
                        {
                            DFS(nnt);
                        }
                    }

                    tsType.IsNullable = tsType.IsNullable || nullTypeCount != 0;
                }
                break;
            case SyntaxKind.ArrayType:
                {
                    tsType.Kind = TsTypeKind.Array;

                    if (type.Children.Count == 1 && type.Children[0] is ITypeNode arrayMemberTypeNode)
                    {
                        tsType.ArrayMemberType = CreateTsType(arrayMemberTypeNode, log);
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
                break;
            case SyntaxKind.FunctionType:
                {
                    tsType.Kind = TsTypeKind.Delegate;

                    var functionTypeNode = (FunctionTypeNode)type;

                    tsType.DelegateReturnType = CreateTsType(functionTypeNode.Type, log);
                    tsType.DelegateParameters = functionTypeNode.Parameters.Select(p => CreateTsType(p.Type, log)).ToList();
                    tsType.DelegateParameterNames = functionTypeNode.Parameters.Select(p => ((Identifier)p.Name).IdentifierStr).ToList();
                }
                break;
            case SyntaxKind.ParenthesizedType:
                {
                    if (type.Children.Count == 1 && type.Children[0] is ITypeNode innerTypeNode)
                    {
                        var innerType = CreateTsType(innerTypeNode, log);
                        tsType.AssignToThis(innerType);
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
                break;
            case SyntaxKind.LastTypeNode:
                {
                    if (type.Children.Count == 1 && type.Children[0] is PrimaryExpression primaryExpression)
                    {
                        tsType.Kind = TsTypeKind.Range;
                        switch (primaryExpression.Kind)
                        {
                            case SyntaxKind.TrueKeyword:
                                tsType.LastType = "true";
                                tsType.Name = "boolean";
                                break;
                            case SyntaxKind.FalseKeyword:
                                tsType.LastType = "false";
                                tsType.Name = "boolean";
                                break;
                            default:
                                System.Diagnostics.Debugger.Break();
                                break;
                        }
                    }
                    else if (type.Children.Count == 1 && type.Children[0] is StringLiteral stringLiteral)
                    {
                        tsType.Kind = TsTypeKind.StringList;
                        tsType.LastType = stringLiteral.Text;
                        tsType.Name = "string";
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
                break;
            case SyntaxKind.TupleType:
                {
                    var tupleTypeNode = (TupleTypeNode)type;
                    var tupleElementTypes = tupleTypeNode.ElementTypes.Select(t => CreateTsType(t, log)).ToList();
                    bool bad = false;
                    foreach (var t in tupleTypeNode.ElementTypes)
                    {
                        if (t.GetText() == tupleTypeNode.ElementTypes[0].GetText())
                        {
                            continue;
                        }
                        bad = true;
                    }
                    if (!bad)
                    {
                        tsType.Kind = TsTypeKind.Array;
                        tsType.ArrayMemberType = tupleElementTypes[0];
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
                break;
            case SyntaxKind.ExpressionWithTypeArguments:
                {
                    var typeReference = (ExpressionWithTypeArguments)type;
                    if ((typeReference.TypeArguments?.Count ?? 0) > 0)
                    {
                        tsType.TypeParameters = typeReference.TypeArguments!.Select(t => CreateTsType(t, log)).ToList();
                    }
                    if (type.Children.Count == 1 + tsType.TypeParameters.Count && type.Children[0] is Identifier)
                    {
                        tsType.Name = type.Children[0].IdentifierStr;
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
                break;
            case SyntaxKind.IntersectionType:
                {
                    // Special case: (WindowProxy & typeof globalThis)
                    // Most of the time this _is_ a WindowProxy, or Window, so just emit a "Window".
                    if (type.GetText().Trim() == "WindowProxy & typeof globalThis"
                        || type.GetText().Trim() == "Window & typeof globalThis")
                    {
                        tsType.Name = "Window";
                    }
                    else
                    {
                        log?.Invoke(type.Pos.GetValueOrDefault(), type.End.GetValueOrDefault(), $"Intersection types ({type.GetText()}) are not supported. Emitting a object instead.");
                        tsType.Name = "object";
                    }
                }
                break;
            case SyntaxKind.IndexedAccessType:
                log?.Invoke(type.Pos.GetValueOrDefault(), type.End.GetValueOrDefault(), $"Indexed access types ({type.GetText()}) are not supported. Emitting a object instead.");
                tsType.Name = "object";
                break;
            case SyntaxKind.TypeLiteral:
                tsType.Kind = TsTypeKind.InlineType;
                tsType.Name = type.GetText();
                break;
            default:
                System.Diagnostics.Debugger.Break();
                break;
        }

        return tsType;
    }

    public static bool GenerateContext(Context context, string? globalInterfaceName, string filePath, string fileText)
    {
        void log(int start, int end, string message)
        {
            context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.UnsupportedFeatureDescriptor,
                Location.Create(filePath, TextSpan.FromBounds(start, end),
                SourceText.From(fileText).Lines.GetLinePositionSpan(TextSpan.FromBounds(start, end))),
                message));
        }

        var getSetAccessorRegex = new Regex(@"^\s*[gs]et .*\n", RegexOptions.Multiline);
        fileText = getSetAccessorRegex.Replace(fileText, m =>
        {
            log(m.Index, m.Index + m.Length, "get/set accessors are not supported.");
            // Do this to preserve source positions.
            return new string(' ', m.Value.Length - Environment.NewLine.Length) + Environment.NewLine;
        });

        var ast = new TypeScriptAST(fileText, filePath);

        var typeAliases = ast.OfKind(SyntaxKind.TypeAliasDeclaration)
            .Cast<TypeAliasDeclaration>()
            .ToList();

        foreach (var t in typeAliases)
        {
            if (!context.TypeAliases.TryGetValue(t.IdentifierStr, out var dict))
            {
                dict = new();
                context.TypeAliases.Add(t.IdentifierStr, dict);
            }

            dict.Add(t.TypeParameters?.Count ?? 0, new Tuple<List<string>, TsType>(t.TypeParameters?.Select(p => p.IdentifierStr).ToList() ?? new List<string>(), CreateTsType(t.Type, log)));
        }

        context.Interfaces = ast.OfKind(SyntaxKind.InterfaceDeclaration)
            .Where(i =>
            {
                if (i.IdentifierStr.EndsWith("EventMap") || i.IdentifierStr.EndsWith("NameMap"))
                {
                    log(i.Pos.GetValueOrDefault(), i.End.GetValueOrDefault(), $"Skipping unsupported map type: {i.IdentifierStr}");
                    return false;
                }
                return true;
            })
            .Select(decl => CreateInterface((InterfaceDeclaration)decl, log))
            .ToList();

        context.InlineInterfaces = ast.OfKind(SyntaxKind.TypeLiteral)
            .Where(lit => lit.Parent?.Kind != SyntaxKind.VariableDeclaration)
            .ToDictionary(lit => lit.GetText(), lit => CreateInterface((TypeLiteralNode)lit, log));

        context.EventMaps = ast.OfKind(SyntaxKind.InterfaceDeclaration)
            .Where(i => i.IdentifierStr.EndsWith("EventMap"))
            .Select(decl => CreateEventMap((InterfaceDeclaration)decl, log))
            .ToList();

        var globalInterface = context.Interfaces.SingleOrDefault(i => i.Name == globalInterfaceName);

        if (globalInterface != null)
        {
            globalInterface.Properties.AddRange(
                ast.RootNode.Children.OfType<VariableStatement>()
                    .SelectMany(statement => statement.DeclarationList.Declarations)
                    .Where(statement => !statement.GetDescendants().OfType<TypeLiteralNode>().Any())
                    .Where(statement => !statement.GetDescendants().OfType<TypeQueryNode>().Any())
                    .Select(statement => CreateProperty(statement, log))
                    .Where(property => !globalInterface.Properties.Where(existingProperty => existingProperty.Name == property.Name).Any())
            );

            globalInterface.Methods.AddRange(
                ast.RootNode.Children.OfType<FunctionDeclaration>()
                    .Where(method => !method.GetText().Contains("extends keyof"))
                    .Select(statement => CreateMethod(statement, log))
                    .Where(method => !globalInterface.Methods.Where(existingMethod => existingMethod.Name == method.Name).Any())
            );
        }

        return true;
    }
}

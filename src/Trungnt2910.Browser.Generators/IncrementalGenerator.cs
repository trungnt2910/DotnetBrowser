using Gobie;
using Gobie.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Immutable;
using System.Text;

namespace Trungnt2910.Browser.Generators;

[Generator]
public class IncrementalGenerator : IIncrementalGenerator
{
    private static Dictionary<string, IHandler> _handlers = new()
    {
        { typeof(MethodGeneratorGeneratorAttribute).FullName, new MethodGeneratorGeneratorHandler() },
        { "MethodGeneratorGenerator", new MethodGeneratorGeneratorHandler() }
    };

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var additionalGeneratorClassesWithModelsValues = context.SyntaxProvider.CreateSyntaxProvider(
           predicate: (s, t) => s is AttributeListSyntax,
           transform: GetGeneratorClasses)
            .Where(s => s is not null)
            .SelectMany((s, ct) => s!.Value.Nodes
                .Where(n => n is ClassDeclarationSyntax)
                .Select(n => new AdditionalClass(n, s.Value.SemanticModel)));

        var additionalGeneratorClassesWithModels = additionalGeneratorClassesWithModelsValues;

        var additionalGeneratorClasses = additionalGeneratorClassesWithModelsValues
            .Select((s, ct) => s.ClassDeclaration)
            .Collect();

        context.RegisterSourceOutput(additionalGeneratorClasses, GenerateSource);

        var gobieGenerator = new GobieGenerator();
        gobieGenerator.Initialize(context, additionalGeneratorClassesWithModels);
    }

    private void GenerateSource(SourceProductionContext context, ImmutableArray<ClassDeclarationSyntax> classList)
    {
        var node = SyntaxFactory.CompilationUnit()
            .WithMembers(new SyntaxList<MemberDeclarationSyntax>((new MemberDeclarationSyntax[] {
                SyntaxFactory.FileScopedNamespaceDeclaration(
                    SyntaxFactory.IdentifierName("Trungnt2910.Browser.Generators")
                    .WithLeadingTrivia(SyntaxFactory.Space)
                )
            }).Concat(classList)
        ));

        var tree = SyntaxFactory.SyntaxTree(node);

        var s = tree.ToString();

        context.AddSource($"GobieGenerators.cs", SourceText.From(tree.ToString(), Encoding.UTF8));
    }

    private (IEnumerable<ClassDeclarationSyntax> Nodes, SemanticModel SemanticModel)? GetGeneratorClasses(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        var decl = (AttributeListSyntax)context.Node;

        if (decl.Parent is CompilationUnitSyntax)
        {
            foreach (var attribute in decl.Attributes)
            {
                if (_handlers.TryGetValue(attribute.Name.ToString(), out IHandler handler))
                {
                    var classNodes = handler.Handle(attribute);

                    var langVersion = (context.SemanticModel.Compilation as CSharpCompilation)?.LanguageVersion ?? LanguageVersion.Latest;

                    var tree = SyntaxFactory.SyntaxTree(
                        SyntaxFactory.CompilationUnit()
                            .WithMembers(new SyntaxList<MemberDeclarationSyntax>((new MemberDeclarationSyntax[] {
                                SyntaxFactory.FileScopedNamespaceDeclaration(
                                    SyntaxFactory.IdentifierName("Trungnt2910.Browser.Generators")
                                    .WithLeadingTrivia(SyntaxFactory.Space)
                                )
                            }).Concat(classNodes)
                        )), 
                        new CSharpParseOptions()
                            .WithLanguageVersion(langVersion));
                    
                    var newCompilation = context.SemanticModel.Compilation.AddSyntaxTrees(tree);

                    // We have to get the nodes DIRECTLY from the tree.
                    return (tree.GetRoot().ChildNodes()
                                .Where(child => child is ClassDeclarationSyntax)
                                .Cast<ClassDeclarationSyntax>(), 
                            newCompilation.GetSemanticModel(tree));
                }
            }
        }

        return null;
    }
}

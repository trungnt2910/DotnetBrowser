using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;

namespace Trungnt2910.Browser.JsInteropGenerators;

[Generator]
public class IncrementalGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var jsImportMembers = context.SyntaxProvider.CreateSyntaxProvider(
           predicate: (s, t) => s is AttributeListSyntax,
           transform: DetectJsImportMembers)
            .Where(s => s is not null)
            .Select((s, t) => s!)
            .Collect();

        context.RegisterSourceOutput(jsImportMembers, GenerateJsImport);
    }

    private void GenerateJsImport(SourceProductionContext context, ImmutableArray<GeneratedMember> memberList)
    {
        foreach (var member in memberList)
        {
            member.Generate(context);
        }
    }

    private GeneratedMember? DetectJsImportMembers(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        return RoslynFactory.Create(context);
    }
}

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Trungnt2910.Browser.Generators;

internal interface IHandler
{
    IEnumerable<ClassDeclarationSyntax> Handle(AttributeSyntax attribute);
}

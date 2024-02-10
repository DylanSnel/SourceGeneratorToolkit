using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace SourceGeneratorsToolkit.SyntaxExtensions;
public static class MemberDeclarationExtensions
{
    public static List<AttributeSyntax> Attributes(this MemberDeclarationSyntax memberDeclarationSyntax)
    {
        return memberDeclarationSyntax.AttributeLists.SelectMany(x => x.Attributes).ToList();
    }

    public static bool HasAttribute<TAttribute>(this MemberDeclarationSyntax memberDeclarationSyntax)
    {
        return Attributes(memberDeclarationSyntax).Any(x => x.Matches<TAttribute>());

    }

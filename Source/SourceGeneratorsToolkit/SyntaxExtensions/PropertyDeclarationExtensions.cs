using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace SourceGeneratorsToolkit.SyntaxExtensions;
public static class PropertyDeclarationExtensions
{
    public static string GetName(this PropertyDeclarationSyntax properyDeclarationSyntax)
    {
        return properyDeclarationSyntax.Identifier.Text;
    }

    public static string GetAccessModifier(this PropertyDeclarationSyntax properyDeclarationSyntax)
    {
        return properyDeclarationSyntax.Modifiers.FirstOrDefault(m => m.IsKind(SyntaxKind.PublicKeyword) || m.IsKind(SyntaxKind.InternalKeyword) || m.IsKind(SyntaxKind.PrivateKeyword)).Text;
    }

    public static bool HasGetter(this PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        return propertyDeclarationSyntax.AccessorList?.Accessors.Any(x => x.IsKind(SyntaxKind.GetAccessorDeclaration) || x.IsKind(SyntaxKind.InitAccessorDeclaration)) ?? false;
    }

    public static bool HasSetter(this PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        return propertyDeclarationSyntax.AccessorList?.Accessors.Any(x => x.IsKind(SyntaxKind.SetAccessorDeclaration) || x.IsKind(SyntaxKind.InitAccessorDeclaration)) ?? false;
    }

    public static bool HasInitSetter(this PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        return propertyDeclarationSyntax.AccessorList?.Accessors.Any(x => x.IsKind(SyntaxKind.InitAccessorDeclaration)) ?? false;
    }

    public static bool HasSetSetter(this PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        return propertyDeclarationSyntax.AccessorList?.Accessors.Any(x => x.IsKind(SyntaxKind.SetAccessorDeclaration)) ?? false;
    }

    public static string GetGetterModifier(this PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        return propertyDeclarationSyntax.AccessorList?.Accessors.FirstOrDefault(x => x.IsKind(SyntaxKind.GetAccessorDeclaration) || x.IsKind(SyntaxKind.InitAccessorDeclaration))?.Modifiers.FirstOrDefault(m => m.IsKind(SyntaxKind.PublicKeyword) || m.IsKind(SyntaxKind.InternalKeyword) || m.IsKind(SyntaxKind.PrivateKeyword) || m.IsKind(SyntaxKind.ProtectedKeyword)).Text ?? "";
    }

    public static string GetSetterModifier(this PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        return propertyDeclarationSyntax.AccessorList?.Accessors.FirstOrDefault(x => x.IsKind(SyntaxKind.SetAccessorDeclaration) || x.IsKind(SyntaxKind.InitAccessorDeclaration))?.Modifiers.FirstOrDefault(m => m.IsKind(SyntaxKind.PublicKeyword) || m.IsKind(SyntaxKind.InternalKeyword) || m.IsKind(SyntaxKind.PrivateKeyword) || m.IsKind(SyntaxKind.ProtectedKeyword)).Text ?? "";
    }

    public static string GetReturnType(this PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        return propertyDeclarationSyntax.Type.ToString().Replace("String", "string");
    }


}

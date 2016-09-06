using System;
using System.Collections.Generic;
using System.Text;
using C = Run.Pug.Mbombo.SyntaxConstants;

namespace Run.Pug.Mbombo
{
    public class CSharpGenerator
    {
        private CSharpGenerator() {}

        public static string GenerateFile(FileDeclaration fileDeclaration)
        {
            StringBuilder sb = new StringBuilder();
            Append(sb, fileDeclaration);
            return sb.ToString();
        }

        private static void Append(StringBuilder sb, FileDeclaration fileDeclaration)
        {
            Append(sb, fileDeclaration.UsingDeclarations);

            if (fileDeclaration.HasNamespaceDeclaration())
            {
                sb.AppendLine(C.NAMESPACE + C.SPACE + fileDeclaration.NamespaceDeclaration.Name);
                sb.AppendLine(C.OPEN_CURLY_BRACKET);

            }

            if (fileDeclaration.HasClassDeclaration())
            {
                Append(sb, fileDeclaration.ClassDeclaration);
            }

            if (fileDeclaration.HasNamespaceDeclaration())
            {
                sb.AppendLine(C.CLOSE_CURLY_BRACKET);
            }
        }

        private static void Append(StringBuilder sb, List<UsingDeclaration> usingDeclarations)
        {
            foreach (UsingDeclaration usingDeclaration in usingDeclarations)
            {
                sb.AppendLine(C.USING + C.SPACE + usingDeclaration.Namespace + C.SEMICOLON);
            }
        }

        public static string GenerateClass(ClassDeclaration classDeclaration)
        {
            StringBuilder sb = new StringBuilder();
            Append(sb, classDeclaration);
            return sb.ToString();
        }

        private static void Append(StringBuilder sb, ClassDeclaration classDeclaration)
        {
            Append(sb, classDeclaration.Modifier);

            if (classDeclaration.IsStatic)
            {
                sb.Append(C.STATIC + C.SPACE);
            }

            sb.Append(C.CLASS + C.SPACE + classDeclaration.Name);

            if (classDeclaration.HasParentClass())
            {
                sb.Append(C.SPACE + C.EXTENDS + C.SPACE + classDeclaration.ParentClass);
            }
            
            sb.AppendLine();
            sb.AppendLine(C.OPEN_CURLY_BRACKET);

            foreach (PropertyDeclaration property in classDeclaration.properties)
            {
                Append(sb, property);
                sb.AppendLine();
            }

            foreach (ClassDeclaration subclass in classDeclaration.subclasses)
            {
                Append(sb, subclass);
                sb.AppendLine();
            }

            sb.AppendLine(C.CLOSE_CURLY_BRACKET);
        }

        public static string GenerateProperty(PropertyDeclaration propertyDeclaration)
        {
            StringBuilder sb = new StringBuilder();
            Append(sb, propertyDeclaration);
            return sb.ToString();
        }

        private static void Append(StringBuilder sb, PropertyDeclaration propertyDeclaration)
        {
            Append(sb, propertyDeclaration.Modifier);

            if (propertyDeclaration.IsStatic)
            {
                sb.Append(C.STATIC + C.SPACE);
            }

            sb.Append(propertyDeclaration.Type + C.SPACE);
            sb.Append(propertyDeclaration.Name);
            
            if (propertyDeclaration.HasValue())
            {
                sb.Append(C.SPACE + C.EQUALS_SIGN + C.SPACE + propertyDeclaration.Value);
            }

            sb.Append(C.SEMICOLON);
        }

        private static string AccessModifierToString(AccessModifier modifier)
        {
            switch (modifier)
            {
                case AccessModifier.DEFAULT:
                    return C.EMPTY_STRING;
                case AccessModifier.PRIVATE:
                    return C.ACCESS_MODIFIER_PRIVATE;
                case AccessModifier.PUBLIC:
                    return C.ACCESS_MODIFIER_PUBLIC;
                case AccessModifier.PROTECTED:
                    return C.ACCESS_MODIFIER_PROTECTED;
                default:
                    throw new Exception();
            }
        }

        private static void Append(StringBuilder sb, AccessModifier modifier)
        {
            string accessModifierText = AccessModifierToString(modifier);
            if (accessModifierText.Length > 0)
            {
                sb.Append(accessModifierText + C.SPACE);
            }
        }
    }
}

using Run.Pug.Mbombo;
using System;
using C = Run.Pug.Mbombo.SyntaxConstants;

namespace Run.Pug.Ugh.Unity
{
    public class TagGenerator : IGenerator
    {
        private const string VALUE_FORMAT = "\"{0}\"";

        public string Name
        {
            get { return "Tag"; }
        }

        public string Generate(string className)
        {
            var classBuilder = new ClassDeclaration.Builder(className)
                    .SetAccessModifer(AccessModifier.PUBLIC);

            foreach (string tagName in UnityEditorInternal.InternalEditorUtility.tags)
            {
                string propertyName = PropertyUtil.CleanName(tagName);

                var property = new PropertyDeclaration.Builder(C.STRING_TYPE, propertyName)
                        .SetAccessModifier(AccessModifier.PUBLIC)
                        .SetValueFormat(VALUE_FORMAT, tagName)
                        .IsStatic(true)
                        .Build();

                classBuilder.AddProperty(property);
            }

            return CSharpGenerator.GenerateClass(classBuilder.Build());
        }
    }
}

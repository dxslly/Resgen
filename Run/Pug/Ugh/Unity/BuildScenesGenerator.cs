using Run.Pug.Mbombo;
using System;
using System.IO;
using C = Run.Pug.Mbombo.SyntaxConstants;
using UnityLayerMask = UnityEngine.LayerMask;

namespace Run.Pug.Ugh.Unity
{
    public class BuildScenesGenerator : IGenerator
    {
        private const string VALUE_FORMAT = "\"{0}\"";

        public string Name
        {
            get { return "BuildScene"; }
        }

        public string Generate(GeneratorOptions options)
        {
            var classBuilder = new ClassDeclaration.Builder(options.ClassName)
                    .SetAccessModifer(AccessModifier.PUBLIC);


            foreach (var scene in UnityEditor.EditorBuildSettings.scenes)
            {
                if (!scene.enabled)
                {
                    continue;
                }

                string sceneName = Path.GetFileNameWithoutExtension(scene.path);
                string propertyName = PropertyUtil.CleanName(sceneName);

                var property = new PropertyDeclaration.Builder(C.STRING_TYPE, propertyName)
                        .SetAccessModifier(AccessModifier.PUBLIC)
                        .SetValueFormat(VALUE_FORMAT, scene.path)
                        .IsStatic(true)
                        .Build();

                classBuilder.AddProperty(property);
            }


            var fileBuilder = new FileDeclaration.Builder()
                    .SetClass(classBuilder.Build());
            if (!options.UseGlobalNamespace)
            {
                fileBuilder.SetNamespace(options.Namespace);
            }

            return CSharpGenerator.GenerateFile(fileBuilder.Build());
        }
    }
}

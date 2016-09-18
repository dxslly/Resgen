using Run.Pug.Mbombo;
using Run.Pug.Patterns;
using System;
using SC = Run.Pug.Mbombo.SyntaxConstants;
using UC = Run.Pug.Ugh.Unity.UnityConstants;
using UnityObject = UnityEngine.Object;
using UnityApplication = UnityEngine.Application;

namespace Run.Pug.Ugh.Unity
{
    public class ResourceGenerator : IGenerator
    {
        private static RegexMatcher metaFileMatcher = new RegexMatcher(@"\.meta$");
        private const string VALUE_FORMAT = "new RToolResource<{0}>(\"{1}\", \"{2}\")";
        private const string PROPERTY_TYPE_FORMAT = "RToolResource<{0}>";

        public string Name
        {
            get { return "Resource"; }
        }

        public string Generate(string className)
        {
            Node baseNode = new NodeBuilder(UnityApplication.dataPath, metaFileMatcher).Build();

            var fileBuilder = new FileDeclaration.Builder();
            var classBuilder = new ClassDeclaration.Builder(className)
                    .IsStatic(true)
                    .SetAccessModifer(AccessModifier.PUBLIC);

            AddNode(classBuilder, baseNode);

            fileBuilder.AddUsingDeclaration<UghResource<UnityObject>>();
            fileBuilder.SetClass(classBuilder.Build());
            return CSharpGenerator.GenerateFile(fileBuilder.Build());
        }

        private static void AddNode(ClassDeclaration.Builder builder, Node node)
        {
            string nodeDirectory = NodeUtil.GetRelativeDirectory(node, UC.DIRECTORY_SEPERATOR);

            foreach (string assetName in node.AssetNames)
            {
                string propertyName = PropertyUtil.CleanName(assetName);
                string assetPath = nodeDirectory + UC.DIRECTORY_SEPERATOR + assetName;
                string assetType = "UnityEngine.Object";
                string propertyType = String.Format(PROPERTY_TYPE_FORMAT, assetType);

                string propertyValue =
                        String.Format(VALUE_FORMAT, assetType, assetPath, assetName);

                var property = new PropertyDeclaration.Builder(propertyType, propertyName)
                        .IsStatic(true)
                        .SetAccessModifier(AccessModifier.PUBLIC)
                        .SetValue(propertyValue)
                        .Build();

                builder.AddProperty(property);
            }

            foreach (Node subnode in node.Subnodes.Values)
            {
                string className = NodeUtil.GetNodeDirectory(subnode);
                var subClassBuilder = new ClassDeclaration.Builder(className)
                        .IsStatic(true)
                        .SetAccessModifer(AccessModifier.PUBLIC);

                AddNode(subClassBuilder, subnode);
                builder.AddSubclass(subClassBuilder.Build());
            }
        }
    }
}

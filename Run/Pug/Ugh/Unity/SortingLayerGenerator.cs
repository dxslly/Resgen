using Run.Pug.Mbombo;
using System;
using System.Collections.Generic;
using UnitySortingLayer = UnityEngine.SortingLayer;

namespace Run.Pug.Ugh.Unity
{
    public class SortingLayerGenerator : IGenerator
    {
        private const string VALUE_TEMPLATE = "new UghSortingLayer({0}, \"{1}\", {2})";

        public string Name
        {
            get { return "SortingLayer"; }
        }

        public string Generate(string className)
        {
            var fileBuilder = new FileDeclaration.Builder()
                    .AddUsingDeclaration<UghSortingLayer>();
            var classBuilder = new ClassDeclaration.Builder(className)
                    .IsStatic(true)
                    .SetAccessModifer(AccessModifier.PUBLIC);

            foreach (UnitySortingLayer sortingLayer in UnitySortingLayer.layers)
            {
                string propertyName = PropertyUtil.CleanName(sortingLayer.name);
                string propertyValue = GetValueString(sortingLayer);

                var propertyBuilder =
                        PropertyDeclaration.GetBuilder<UghSortingLayer>(propertyName)
                                .SetAccessModifier(AccessModifier.PUBLIC)
                                .IsStatic(true)
                                .SetValue(propertyValue);

                classBuilder.AddProperty(propertyBuilder.Build());
            }

            fileBuilder.SetClass(classBuilder.Build());
            return CSharpGenerator.GenerateFile(fileBuilder.Build());
        }

        private static string GetValueString(UnitySortingLayer sortingLayer)
        {
            return string.Format(VALUE_TEMPLATE,
                    sortingLayer.id,
                    sortingLayer.name,
                    sortingLayer.value);
        }
    }
}

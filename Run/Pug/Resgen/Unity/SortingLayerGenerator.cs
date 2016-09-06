using Run.Pug.Mbombo;
using System;
using System.Collections.Generic;
using UnitySortingLayer = UnityEngine.SortingLayer;

namespace Run.Pug.Resgen.Unity
{
    public class SortingLayerGenerator : IClassGenerator
    {
        private const string VALUE_TEMPLATE = "new RToolSortingLayer({0}, \"{1}\", {2})";

        public string DefaultClassName
        {
            get { return "SortingLayer"; }
        }

        public string GenerateClass(string className)
        {
            var fileBuilder = new FileDeclaration.Builder()
                    .AddUsingDeclaration<RToolSortingLayer>();
            var classBuilder = new ClassDeclaration.Builder(className)
                    .IsStatic(true)
                    .SetAccessModifer(AccessModifier.PUBLIC);

            foreach (UnitySortingLayer sortingLayer in UnitySortingLayer.layers)
            {
                string propertyName = PropertyUtil.CleanName(sortingLayer.name);
                string propertyValue = GetValueString(sortingLayer);

                var propertyBuilder =
                        PropertyDeclaration.GetBuilder<RToolSortingLayer>(propertyName)
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

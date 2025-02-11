﻿using Run.Pug.Mbombo;
using System;
using C = Run.Pug.Mbombo.SyntaxConstants;
using UnityLayerMask = UnityEngine.LayerMask;

namespace Run.Pug.Resgen.Unity
{
    public class LayerGenerator : IClassGenerator
    {
        private const int MAX_NUM_LAYERS = 32;

        public string DefaultClassName
        {
            get { return "Layer"; }
        }

        public string GenerateClass(string className)
        {
            var classBuilder = new ClassDeclaration.Builder(className)
                    .SetAccessModifer(AccessModifier.PUBLIC);

            for (int layerIndex = 0; layerIndex < MAX_NUM_LAYERS; layerIndex++)
            {
                string layerName = UnityLayerMask.LayerToName(layerIndex);

                if (0 == layerName.Length)
                {
                    continue;
                }

                string layerPropertyName = PropertyUtil.CleanName(layerName);
                var property = new PropertyDeclaration.Builder(C.INT_TYPE, layerPropertyName)
                        .SetAccessModifier(AccessModifier.PUBLIC)
                        .SetValue(layerIndex.ToString())
                        .IsStatic(true)
                        .Build();

                classBuilder.AddProperty(property);
            }

            return CSharpGenerator.GenerateClass(classBuilder.Build());
        }

    }
}

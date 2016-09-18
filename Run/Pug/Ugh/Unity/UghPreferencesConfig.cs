using System;
using System.Collections.Generic;
using System.Linq;
using Run.Pug.Util;
using Run.Pug.Util.Unity;

namespace Run.Pug.Ugh.Unity
{
    [Serializable]
    public class UghPreferencesConfig : UnityEditorConfig
    {
        private const string EDITOR_PREFS_KEY = "Run.Pug.Ugh";

        public string GeneratePath = "Source-Gen/Ugh/";
        public string CustomNamespace = "";
        public string ClassNamePrefix = "";
        public string ClassNameSuffix = "";

        public List<GeneratorConfig> generatorConfigs = new List<GeneratorConfig>();

        public UghPreferencesConfig() : base(EDITOR_PREFS_KEY) {}

        public GeneratorConfig GetGeneratorConfig(IGenerator generator)
        {
            // Unity3d serialization doesn't support dictionaries :( so I'll do this for now
            GeneratorConfig config =
                    generatorConfigs.FirstOrDefault(c => c.Name.Equals(generator.Name));
            if (null == config)
            {
                config = new GeneratorConfig(generator.Name);
                generatorConfigs.Add(config);
            }

            return config;
        }

        [Serializable]
        public class GeneratorConfig
        {
            public string Name;
            public bool IsEnabled = true;
            public string CustomClassName = "";

            public GeneratorConfig(string name)
            {
                Name = name;
            }
        }
    }
}

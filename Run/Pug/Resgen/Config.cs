using System;
using System.Collections.Generic;

namespace Run.Pug.Resgen
{
    public class Config
    {
        public string ClassNamePrefix { get; private set; }
        public string ClassNameSuffix { get; private set; }
        public string GeneratePath { get; private set; }

        private Dictionary<string, string> CustomClassName { get; set; }

        public string GetCustomClassName(IClassGenerator generator)
        {
            string fullName = generator.GetType().FullName;
            if (CustomClassName.ContainsKey(fullName))
            {
                return CustomClassName[fullName];
            }

            return null;
        }

        public void SetCustomClassName(IClassGenerator generator, string customName)
        {
            CustomClassName.Add(generator.GetType().FullName, customName);
        }
    }
}
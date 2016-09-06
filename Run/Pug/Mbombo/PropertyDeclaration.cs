using System;

namespace Run.Pug.Mbombo
{
    public class PropertyDeclaration
    {
        public AccessModifier Modifier { get; private set; }
        public bool IsStatic { get; private set; }
        public string Type { get; private set; } 
        public string Name { get; private set; }
        public string Value { get; private set; }

        public bool HasValue()
        {
            return null != Value;
        }

        public static Builder GetBuilder<T>(string name)
        {
            return new Builder(typeof(T).Name, name);
        }

        public class Builder
        {
            private PropertyDeclaration instance = new PropertyDeclaration();

            public Builder(string type, string name)
            {
                instance.IsStatic = false;
                instance.Modifier = AccessModifier.DEFAULT;
                instance.Type = type;
                instance.Name = name;
                instance.Value = null;
            }

            public PropertyDeclaration Build()
            {
                return instance;
            }

            public Builder SetName(string name)
            {
                instance.Name = name;
                return this;
            }

            public Builder SetAccessModifier(AccessModifier modifier)
            {
                instance.Modifier = modifier;
                return this;
            }

            public Builder SetValue(string value)
            {
                instance.Value = value;
                return this;
            }

            public Builder RemoveValue()
            {
                instance.Value = null;
                return this;
            }

            public Builder IsStatic(bool isStatic)
            {
                instance.IsStatic = isStatic;
                return this;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Run.Pug.Mbombo
{
    public class ClassDeclaration
    {
        public AccessModifier Modifier { get; private set; }
        public Boolean IsStatic { get; private set; }
        public string Name { get; private set; }
        public string ParentClass { get; private set; }
        public List<PropertyDeclaration> properties { get; private set; }
        public List<ClassDeclaration> subclasses { get; private set; }

        private ClassDeclaration()
        {
            properties = new List<PropertyDeclaration>();
            subclasses = new List<ClassDeclaration>();
        }

        public Boolean HasParentClass()
        {
            return null != ParentClass;
        }

        public class Builder
        {
            private ClassDeclaration instance = new ClassDeclaration();

            public Builder(string className)
            {
                instance.Modifier = AccessModifier.DEFAULT;
                instance.IsStatic = false;
                instance.Name = className;
            }

            public ClassDeclaration Build()
            {
                return instance;
            }

            public Builder SetAccessModifer(AccessModifier modifier)
            {
                instance.Modifier = modifier;
                return this;
            }

            public Builder SetName(string name)
            {
                instance.Name = name;
                return this;
            }

            public Builder SetParentClass(string name)
            {
                instance.ParentClass = name;
                return this;
            }

            public Builder SetParentClass<T>()
            {
                return SetParentClass(typeof(T).Name);
            }

            public Builder IsStatic(Boolean isStatic)
            {
                instance.IsStatic = isStatic;
                return this;
            }

            public Builder AddProperty(PropertyDeclaration property)
            {
                instance.properties.Add(property);
                return this;
            }

            public Builder AddSubclass(ClassDeclaration classDeclaration)
            {
                instance.subclasses.Add(classDeclaration);
                return this;
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Run.Pug.Mbombo
{
    public class FileDeclaration
    {
        public List<UsingDeclaration> UsingDeclarations { get; private set; }
        public NamespaceDeclaration NamespaceDeclaration { get; private set; }
        public ClassDeclaration ClassDeclaration { get; private set; }

        private FileDeclaration() {}

        public Boolean HasClassDeclaration()
        {
            return null != ClassDeclaration;
        }

        public Boolean HasNamespaceDeclaration()
        {
            return null != NamespaceDeclaration;
        }

        public class Builder
        {
            private FileDeclaration instance = new FileDeclaration();

            public Builder()
            {
                instance.UsingDeclarations = new List<UsingDeclaration>();
            }

            public FileDeclaration Build()
            {
                return instance;
            }

            public Builder AddUsingDeclaration(string namespaceText)
            {
                instance.UsingDeclarations.Add(new UsingDeclaration(namespaceText));
                return this;
            }

            public Builder AddUsingDeclaration<T>()
            {
                return AddUsingDeclaration(typeof(T).Namespace);
            }

            public Builder SetNamespace(NamespaceDeclaration namespaceDeclaration)
            {
                instance.NamespaceDeclaration = namespaceDeclaration;
                return this;
            }

            public Builder SetClass(ClassDeclaration classDeclaration)
            {
                instance.ClassDeclaration = classDeclaration;
                return this;
            }
        }
    }
}

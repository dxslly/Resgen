namespace Run.Pug.Ugh
{
    public class GeneratorOptions
    {
        public string Namespace { get; private set; }
        public string ClassName { get; private set; }

        public bool UseGlobalNamespace
        {
            get { return null == Namespace; }
        }

        private GeneratorOptions() {}

        public class Builder
        {
            private GeneratorOptions instance;

            public Builder(string className)
            {
                instance = new GeneratorOptions();
                instance.ClassName = className;
            }

            public Builder SetNamespace(string namespaceText)
            {
                instance.Namespace = namespaceText;
                return this;
            }

            public Builder UseGlobalNamespace()
            {
                instance.Namespace = null;
                return this;
            }
        }
    }
}

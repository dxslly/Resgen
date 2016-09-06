namespace Run.Pug.Mbombo
{
    public class UsingDeclaration
    {
        public string Namespace { get; private set; }

        public UsingDeclaration(string namespaceText)
        {
            this.Namespace = namespaceText;
        }
    }
}

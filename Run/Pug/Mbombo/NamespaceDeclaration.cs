namespace Run.Pug.Mbombo
{
    public class NamespaceDeclaration
    {
        public string Name { get; private set; }

        public NamespaceDeclaration(string name, ClassDeclaration classDeclaration)
        {
            this.Name = name;
        }
    }
}

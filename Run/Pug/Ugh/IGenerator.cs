using System;

namespace Run.Pug.Ugh
{
    public interface IGenerator
    {
        string Name { get; }
        string Generate(GeneratorOptions options);
    }
}

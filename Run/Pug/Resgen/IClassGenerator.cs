using System;

namespace Run.Pug.Resgen
{
    public interface IClassGenerator
    {
        string DefaultClassName { get; }
        string GenerateClass(string className);
    }
}

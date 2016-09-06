using Run.Pug.Diagnostics;
using Run.Pug.Patterns;
using Run.Pug.Util;

namespace Run.Pug.Resgen
{
    public class Resgen
    {
        private const string CSHARP_FILE_EXTENSION = ".cs";

        public static void GenerateClass(IClassGenerator generator, Config config)
        {
            string className = config.GetCustomClassName(generator).Or(generator.DefaultClassName);
            string fileContents = generator.GenerateClass(className);

            string directory = FileUtil.GetSafeDirectoryPath(config.GeneratePath);
            string path = directory + className + CSHARP_FILE_EXTENSION;
            FileUtil.WriteFile(path, fileContents);
        }
    }
}
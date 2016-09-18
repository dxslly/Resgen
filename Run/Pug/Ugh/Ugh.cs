using Run.Pug.Diagnostics;
using Run.Pug.Patterns;
using Run.Pug.Util;

namespace Run.Pug.Ugh
{
    public class Ugh
    {
        private const string CSHARP_FILE_EXTENSION = ".cs";

        public static void GenerateClass(IGenerator generator, string path, string className)
        {
            string fileContents = generator.Generate(className);

            string directory = FileUtil.GetSafeDirectoryPath(path);
            string finalPath = directory + className + CSHARP_FILE_EXTENSION;
            FileUtil.WriteFile(finalPath, fileContents);
        }
    }
}
using System.IO;
using System.Collections.Generic;

namespace Run.Pug.Util
{
    public class FileUtil
    {
        public static void WriteFile(string path, string contents)
        {
            string directoryPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(path, contents);
        }

        public static string GetSafeDirectoryPath(string directoryPath)
        {
            if (directoryPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                return directoryPath;
            }

            return directoryPath + Path.DirectorySeparatorChar;
        }
    }
}
using System.IO;
using UnityEngine;

namespace Run.Pug.Util
{
    public class UnityFileUtil
    {
        private const string RESOURCE_FOLDER_NAME_PATTERN = "resources";

        public static string[] getResourceFolders()
        {
            return Directory.GetDirectories(Application.dataPath, 
                    RESOURCE_FOLDER_NAME_PATTERN, SearchOption.AllDirectories);
        }

        public static void WriteFile(string path, string contents)
        {
        }
    }
}
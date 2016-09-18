using System.IO;
using UnityEngine;

namespace Run.Pug.Util.Unity
{
    public class UnityFileUtil
    {
        private const string RESOURCE_FOLDER_NAME_PATTERN = "resources";

        public static string[] getResourceFolders()
        {
            return Directory.GetDirectories(Application.dataPath, 
                    RESOURCE_FOLDER_NAME_PATTERN, SearchOption.AllDirectories);
        }
    }
}
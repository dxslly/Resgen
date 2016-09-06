using UnityEditor;
using UnityEngine;
using Run.Pug.Util;

namespace Run.Pug.Resgen.Unity.Editor
{
    class ResgenWindow : EditorWindow
    {
        [MenuItem("Window/RTool")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<ResgenWindow>();
        }

        private void OnGUI()
        {
        }
    }
}

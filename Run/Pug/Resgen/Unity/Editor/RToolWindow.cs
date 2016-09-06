using UnityEditor;
using UnityEngine;
using Run.Pug.Util;

namespace Run.Pug.Resgen.Unity.Editor
{
    class RToolWindow : EditorWindow
    {
        [MenuItem("Window/RTool")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<RToolWindow>();
        }

        private void OnGUI()
        {
        }
    }
}

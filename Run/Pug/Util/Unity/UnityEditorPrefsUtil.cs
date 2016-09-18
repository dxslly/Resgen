using JsonUtility = UnityEngine.JsonUtility;
using EditorPrefs = UnityEditor.EditorPrefs;

namespace Run.Pug.Util.Unity
{
    public class UnityEditorPrefsUtil
    {
        private UnityEditorPrefsUtil() {}

        public static T Load<T>(string key) where T : new()
        {
            T obj = new T();
            string jsonString = EditorPrefs.GetString(key);
            JsonUtility.FromJsonOverwrite(jsonString, obj);
            return obj;
        }

        public static void Load<T>(string key, T obj)
        {
            string jsonString = EditorPrefs.GetString(key);
            JsonUtility.FromJsonOverwrite(jsonString, obj);
        }

        public static void Save(string key, object obj)
        {
            string jsonConfig = JsonUtility.ToJson(obj);
            EditorPrefs.SetString(key, jsonConfig);
        }
    }
}

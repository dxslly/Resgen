namespace Run.Pug.Util.Unity
{
    public abstract class UnityEditorConfig
    {
        protected string Key { get; private set; }

        public UnityEditorConfig(string key)
        {
            Key = key;
        }

        public void Save()
        {
            UnityEditorPrefsUtil.Save(Key, this);
        }
        
        public void Load()
        {
            UnityEditorPrefsUtil.Load(Key, this);
        }
    }
}

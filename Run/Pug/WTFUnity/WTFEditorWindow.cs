using UnityEditorWindow = UnityEditor.EditorWindow;
using Run.Pug.Util.Unity;
using Debug = UnityEngine.Debug;

namespace Run.Pug.WTFUnity
{
    /**
     * A replacement class for Unity3D's EditorWindow.
     * Initialize -> Enable -> Draw -> Disable -> Destroy
     */
    public abstract class WTFEditorWindow : UnityEditorWindow
    {
        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            Enable();
        }

        private void OnDisable()
        {
            Disable();
        }

        private void OnGUI()
        {
            Draw();
        }

        private void OnDestroy()
        {
            Destroy();
        }

        protected virtual void Initialize() {}
        protected virtual void Enable() {}
        protected virtual void Draw() {}
        protected virtual void Disable() {}
        protected virtual void Destroy() {}

    }
}

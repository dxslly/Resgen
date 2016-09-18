namespace Run.Pug.Util
{
    public abstract class LazySingletonBase<T> where T : LazySingletonBase<T>, new()
    {
        private static T instance { get; set; }

        public static T Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}

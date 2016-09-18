using System;
using UnityResources = UnityEngine.Resources;
using UnityObject = UnityEngine.Object;

namespace Run.Pug.Ugh.Unity
{
    public class UghResource<T> where T : UnityObject
    {
        public Type Type
        {
            get { return typeof(T); }
        }

        public string Path { get; private set; }
        public string Name { get; private set; }

        public UghResource(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public static implicit operator T(UghResource<T> resource)
        {
            return UnityResources.Load<T>(resource.Path);
        }
    }
}

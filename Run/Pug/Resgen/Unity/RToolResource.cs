using System;
using UnityResources = UnityEngine.Resources;
using UnityObject = UnityEngine.Object;

namespace Run.Pug.Resgen.Unity
{
    public class RToolResource<T> where T : UnityObject
    {
        public Type Type
        {
            get { return typeof(T); }
        }

        public string Path { get; private set; }
        public string Name { get; private set; }

        public RToolResource(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public static implicit operator T(RToolResource<T> resource)
        {
            return UnityResources.Load<T>(resource.Path);
        }
    }
}

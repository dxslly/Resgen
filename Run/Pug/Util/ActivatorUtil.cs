using Run.Pug.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Run.Pug.Util
{
    public class ActivatorUtil
    {
        private ActivatorUtil() {}

        public static List<T> CreateInstancesFromInterface<T>()
        {
            var interfaceType = typeof(T);
            Preconditions.ensureTrue(interfaceType.IsInterface, "Type given must be an interface");

            return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => interfaceType.IsAssignableFrom(x)
                           && !x.IsInterface
                           && !x.IsAbstract)
                    .Select<Type, T>(x => (T) Activator.CreateInstance(x))
                    .ToList();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Run.Pug.Diagnostics
{
    public static class Preconditions
    {
        public static void ensureTrue(this bool boolean)
        {
            ensureTrue(boolean, "Expected value to be true");
        }
        
        public static void ensureTrue(this bool boolean, string errorMessage)
        {
            if (!boolean)
            {
                throw new InvalidStateException(errorMessage);
            }
        }

        public static void ensureNonNull(this object obj)
        {
            ensureNonNull(obj, "Expected value to be nonNull");
        }

        public static void ensureNonNull(this object obj, string errorMessage)
        {
            if (null == obj)
            {
                throw new InvalidStateException(errorMessage);
            }
        }

        public static void ensureNonEmpty(this object[] array)
        {
            ensureNonEmpty(array, "Expected array to not be empty");
        }

        public static void ensureNonEmpty(this object[] array,
                string errorMessage)
        {
            if (array.Length == 0)
            {
                throw new InvalidStateException(errorMessage);
            }
        }

        public static void ensureNonEmpty(this string str)
        {
            ensureNonEmpty(str, "Expected string to not be empty");
        }

        public static void ensureNonEmpty(this string str, string errorMessage)
        {
            if (str.Length == 0)
            {
                throw new InvalidStateException(errorMessage);
            }
        }

        public class InvalidStateException : Exception
        {
            public InvalidStateException(string message) : base(message) {}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Run.Pug.Patterns
{
    public class BlackListMatcher<T> : IPatternMatcher<T>
    {
        private IPatternMatcher<T>[] list;

        public BlackListMatcher(IPatternMatcher<T>[] list)
        {
            this.list = list;
        }

        public Boolean IsMatch(T input)
        {
            foreach (IPatternMatcher<T> matcher in list)
            {
                if (matcher.IsMatch(input))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

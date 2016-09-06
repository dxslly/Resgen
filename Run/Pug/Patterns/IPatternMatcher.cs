using System;

namespace Run.Pug.Patterns
{
    public interface IPatternMatcher<T>
    {
        Boolean IsMatch(T input);
    }
}
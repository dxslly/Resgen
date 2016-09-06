using System;
using System.Text.RegularExpressions;

namespace Run.Pug.Patterns
{
    public class RegexMatcher : IPatternMatcher<string>
    {
        private Regex regex;

        public RegexMatcher(string pattern)
        {
            regex = new Regex(pattern);
        }

        public RegexMatcher(Regex regex)
        {
            this.regex = regex;
        }

        public Boolean IsMatch(string text)
        {
            return regex.IsMatch(text);
        }
    }
}

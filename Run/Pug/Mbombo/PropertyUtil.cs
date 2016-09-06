using C = Run.Pug.Mbombo.SyntaxConstants;

namespace Run.Pug.Mbombo
{
    public class PropertyUtil
    {
        // A simple attempt to make a string into a valid property name.  Very basic
        // implementation that does not yet support many cases.
        public static string CleanName(string name)
        {
            return name.Trim().Replace(C.SPACE, C.UNDERSCORE);
        }
    }
}

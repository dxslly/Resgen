namespace Run.Pug.Util
{
    public static class GetOrExtension
    {
        public static T Or<T>(this T nullable, T other)
        {
            if (null == nullable)
            {
                return other;
            }

            return nullable;
        }
    }
}

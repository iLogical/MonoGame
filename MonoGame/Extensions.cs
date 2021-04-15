namespace MonoGame
{
    public static class Extensions
    {
        public static bool Invert(this bool val)
        {
            return !val;
        }

        public static bool IsNullOrEmpty(this string val)
        {
            return string.IsNullOrEmpty(val);
        }

        public static bool IsNullOrWhiteSpace(this string val)
        {
            return string.IsNullOrWhiteSpace(val);
        }

        public static bool IsNull(this object val)
        {
            return val == null;
        }

        public static bool IsNotNull(this object val)
        {
            return val != null;
        }
    }
}
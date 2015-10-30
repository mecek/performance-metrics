namespace PerformanceMetrics
{
    public static class NumberExtensions
    {
        public static string RoundedString(this float value)
        {
            return string.Format("{0:0.00}", value);
        }

        public static float ByteTokb(this float value)
        {
            var kb = value / 1024;
            return kb;
        }

        public static float BitToMBPS(this float value)
        {
            return value / 1000000;
        }
    }
}
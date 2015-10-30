using System;
using System.Text;

namespace PerformanceMetrics
{
    public interface ILogger
    {
        void Log(string result);
    }

    public class PerformanceLogger : ILogger
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public void Log(string result)
        {
            Console.WriteLine(result);
            _stringBuilder.AppendLine(result);
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
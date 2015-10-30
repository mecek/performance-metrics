using System;

namespace PerformanceMetrics
{
    public interface IMeter : IDisposable
    {
        void Calculate(ILogger logger);
    }
}
using System.Diagnostics;

namespace PerformanceMetrics
{
    public class CpuMeter : IMeter
    {
        private readonly PerformanceCounter _performanceCounter;

        public CpuMeter()
        {
            _performanceCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total", true);
        }

        public void Calculate(ILogger logger)
        {
            var value = _performanceCounter.NextValue();
            logger.Log("CPU Usage Total: % " + value);
        }

        public void Dispose()
        {
            _performanceCounter.Dispose();
        }
    }
}
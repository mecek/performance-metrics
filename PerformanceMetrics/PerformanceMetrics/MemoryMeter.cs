using System.Diagnostics;

namespace PerformanceMetrics
{
    public class MemoryMeter : MeterWithPerformanceCounter
    {
        public MemoryMeter() : base(new PerformanceCounter("Memory", "% Committed Bytes In Use"))
        {
        }

        public override void Calculate(ILogger logger)
        {
            logger.Log("Memory Usage Total: % " + base.Counter.NextValue().RoundedString());
        }
    }
}
using System;
using System.Diagnostics;

namespace PerformanceMetrics
{
    public class MeterWithPerformanceCounter : IMeter
    {
        protected readonly PerformanceCounter Counter;

        public MeterWithPerformanceCounter(PerformanceCounter counter)
        {
            Counter = counter;
        }

        public void Dispose()
        {
            Counter.Dispose();
        }

        public virtual void Calculate(ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
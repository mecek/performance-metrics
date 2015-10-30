using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace PerformanceMetrics
{
    public class PerformanceMeter : IMeter
    {
        public List<IMeter> Meters = new List<IMeter>();

        public PerformanceMeter()
        {
            Config = new Configuration();
            Meters.Add(new CpuMeter());
            Meters.Add(new MemoryMeter());
            Meters.Add(new NetworkMeter());
            Meters.Add(new TcpConnectionsMeter());
        }
        public Configuration Config { get; set; }
        public class Configuration
        {
            public int FrequencyInMilliseconds { get; set; }
            public int DurationToRunInMilliseconds { get; set; }
        }

        public void Calculate(ILogger logger)
        {
            var startedOn = DateTime.UtcNow;
            var stopOn = startedOn.AddMilliseconds(Config.DurationToRunInMilliseconds);
            while (DateTime.UtcNow < stopOn)
            {
                logger.Log(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                Meters.ForEach(meter => meter.Calculate(logger));
                Thread.Sleep(Config.FrequencyInMilliseconds);
                logger.Log("--------");
            }
        }

        public void Dispose()
        {
            Meters.ForEach(m => m.Dispose());
        }

        ~PerformanceMeter()
        {
            Dispose();
        }
    }
}

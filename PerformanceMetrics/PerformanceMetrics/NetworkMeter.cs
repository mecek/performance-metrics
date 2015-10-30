using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerformanceMetrics
{
    public class NetworkMeter : IMeter
    {
        private List<NetworkAdapter> _adapters;

        public class NetworkAdapter : IDisposable
        {
            public PerformanceCounter CurrentBandwidth { get; private set; }
            public NetworkAdapter(string adaptername)
            {
                CurrentBandwidth = new PerformanceCounter("Network Interface", "Current Bandwidth", adaptername);
                BytesSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", adaptername);
                BytesReceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", adaptername);
            }

            public PerformanceCounter BytesReceived { get; private set; }

            public PerformanceCounter BytesSent { get; private set; }

            public void Dispose()
            {
                CurrentBandwidth.Dispose();
                BytesSent.Dispose();
                BytesReceived.Dispose();
            }
        }

        public NetworkMeter()
        {
            DiscoverNetworkAdapters();
        }

        private void DiscoverNetworkAdapters()
        {
            var networkInterfaces = new PerformanceCounterCategory("Network Interface");
            _adapters = networkInterfaces.GetInstanceNames().Select(na => new NetworkAdapter(na)).ToList();
        }

        public void Calculate(ILogger logger)
        {
            var totalBandwidthCurrently = _adapters.Sum(a => a.CurrentBandwidth.NextValue());
            var totalBytesSent = _adapters.Sum(a => a.BytesSent.NextValue());
            var totalBytesReceived = _adapters.Sum(a => a.BytesReceived.NextValue());
            logger.Log("All network adapters");
            logger.Log("Total Bandwidth: " + totalBandwidthCurrently.BitToMBPS().RoundedString() + " Mbps.");
            logger.Log("Bytes Sent/sec: " + totalBytesSent.ByteTokb().RoundedString() + " KB");
            logger.Log("Bytes Received/sec: " + totalBytesReceived.ByteTokb().RoundedString() + " KB");
        }

        public void Dispose()
        {
            _adapters.ForEach(a => a.Dispose());
        }
    }
}
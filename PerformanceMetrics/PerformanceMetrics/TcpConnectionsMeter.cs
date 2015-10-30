using System.Net.NetworkInformation;

namespace PerformanceMetrics
{
    public class TcpConnectionsMeter : IMeter
    {
        public void Dispose() { }

        public void Calculate(ILogger logger)
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var numberOfConnections = properties.GetActiveTcpConnections().Length;
            logger.Log("Num. of TCP conn.: " + numberOfConnections);
        }
    }
}
using System.Linq;
using Moq;
using NUnit.Framework;

namespace PerformanceMetrics.UnitTests
{
    [TestFixture]
    public class Given_CpuMeter
    {
        [Test]
        public void When_calculating_cpu_usage()
        {
            using (var cpu = new CpuMeter())
            {
                var logger = new Mock<ILogger>();
                cpu.Calculate(logger.Object);
                logger.Verify(x => x.Log(It.Is(
                    (string log) => float.Parse(log.Split("CPU Usage Total: %".ToCharArray()).Last()) <= 100
                    )));
            }
        }
    }
}

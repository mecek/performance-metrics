using FluentAssertions;
using NUnit.Framework;

namespace PerformanceMetrics.UnitTests
{
    [TestFixture]
    public class NumberExtentionsTests
    {
        [Test]
        public void When_rounding_a_float_value()
        {
            123.1234f.RoundedString().Should().Be("123,12");
        }

        [Test]
        public void When_converting_byte_to_kb()
        {
            2048f.ByteTokb().Should().Be(2f);
        }

        [Test]
        public void When_converting_bits_to_mbits()
        {
            3000000f.BitToMBPS().Should().Be(3f);
        }
    }
}

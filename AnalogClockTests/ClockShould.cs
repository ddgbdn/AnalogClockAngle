using NUnit.Framework;
using Services;

namespace AnalogClockTests
{
    public class ClockShould
    {
        [TestCase(12, 0, 0)]
        [TestCase(12, 30, 165)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 59, 35.5)]
        [TestCase(5, 7.77, 107.265)]
        public void ReturnCorrectAngle(int hours, double minutes, double expectedAngle)
        {
            var actualAngle = new Clock(hours, minutes).Angle;

            Assert.That(actualAngle, Is.EqualTo(expectedAngle).Within(1e-5));
        }

        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(60, 60)]
        [TestCase(int.MaxValue, double.NegativeInfinity)]
        public void ThrowIfIncorrectInput(int hours, double minutes)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Clock(hours, minutes));
        }
    }
}
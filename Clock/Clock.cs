using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public readonly struct Clock
    {
        public int Hours { get; init; }
        public double Minutes { get; init; }
        public double Angle { get; init; }

        public Clock() : this(0, 0)
        {
        }

        public Clock(int hours, double minutes)
        {
            if (hours < 0)
                throw new ArgumentOutOfRangeException(nameof(hours));

            if (minutes < 0 || minutes >= 60)
                throw new ArgumentOutOfRangeException(nameof(minutes));

            Hours = hours % 12;
            Minutes = minutes;
            Angle = ComputeAngle(hours, minutes);
        }

        private static double ComputeAngle(int hours, double minutes)
        {
            var hourAngle = hours * 30 + (0.5 * minutes);
            var minutesAngle = minutes * 6;

            var resultingAngle = Math.Abs(hourAngle - minutesAngle);

            return Math.Min(resultingAngle, 360 -  resultingAngle);
        }
    }
}

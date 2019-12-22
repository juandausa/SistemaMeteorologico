using System;

namespace Entities.WeatherControl
{
    public class Line
    {
        public double Slope { get; }
        public double YIntercept { get; }
        public int DecimalPrecision { get; }

        /// <summary>
        /// Define rect between a and b. y = m.x + b.
        /// y = m.x + b
        /// a.x + b.y + c = 0
        /// =>
        /// y = (-a.x - c) / b  => y = -a / b.x -c / b
        /// =>
        /// m = -a / b
        /// b = -c / b
        /// </summary>
        /// <param name="pointA">Point a</param>
        /// <param name="pointB">Point b</param>
        /// <param name="decimalPrecision">Decimal precision</param>
        public Line((double x, double y) pointA, (double x, double y) pointB, int decimalPrecision = 2)
        {
            if (pointA.Distance(pointB, decimalPrecision) == 0)
            {
                throw new ArgumentException("A line is defined by two differents points");
            }

            this.DecimalPrecision = decimalPrecision;

            var m = pointA.y - pointB.y;
            var b = pointB.x - pointA.x;
            var c = pointA.x * pointB.y - pointB.x * pointA.y;

            if (b == 0)
            {
                this.Slope = 0;
                this.YIntercept = 0;
            }
            else
            {
                this.Slope = (-1) * m / b;
                this.YIntercept = (-1) * c / b;
            }
        }

        public bool Contains((double x, double y) point)
        {
            return Math.Round(point.y, this.DecimalPrecision) == Math.Round(this.Slope * point.x + this.YIntercept, this.DecimalPrecision);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Line))
            {
                return false;
            }

            if (obj == null)
            {
                return false;
            }

            var line = (Line)obj;
            return this.Slope == line.Slope && this.YIntercept == line.YIntercept;
        }

        public override int GetHashCode()
        {
            return this.Slope.GetHashCode() + this.YIntercept.GetHashCode();
        }
    }
}

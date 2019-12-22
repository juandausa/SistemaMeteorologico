using System;
using System.Collections.ObjectModel;

namespace Entities.WeatherControl
{
    public class Triangle
    {
        public (double x, double y) A { get; }
        public (double x, double y) B { get; }
        public (double x, double y) C { get; }
        public int DecimalPresicion { get; }
        public double Perimeter { get; }

        public Triangle((double x, double y) a, (double x, double y) b, (double x, double y) c, int decimalPresicion)
        {
            if (decimalPresicion < 0)
            {
                throw new ArgumentException(nameof(decimalPresicion));
            }

            this.DecimalPresicion = decimalPresicion;
            this.A = a;
            this.B = b;
            this.C = c;
            this.Perimeter = Math.Round(this.A.Distance(this.B, this.DecimalPresicion) + this.B.Distance(this.C, this.DecimalPresicion) + this.C.Distance(this.A, this.DecimalPresicion), this.DecimalPresicion);
        }

        public Triangle((double x, double y) a, (double x, double y) b, (double x, double y) c) : this(a, b, c, 2) { }

        /// <summary>
        /// Returns true if the point is within the triangle, false otherwise.
        /// Based on http://www.dma.fi.upm.es/personal/mabellanas/tfcs/kirkpatrick/Aplicacion/algoritmos.htm#puntoInteriorDefinicion
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>True if the point is within the triangle, false otherwise</returns>
        public bool Contains((double x, double y) point)
        {
            if (new Collection<(double, double)>() { this.A, this.B, this.C }.Contains(point))
            {
                return true;
            }

            var originalDirection = this.CalculateDirection(this.A, this.B, this.C);
            return originalDirection == this.CalculateDirection(this.A, this.B, point) && originalDirection == this.CalculateDirection(this.B, this.C, point) && originalDirection == this.CalculateDirection(this.C, this.A, point);
        }

        private int CalculateDirection((double x, double y) a, (double x, double y) b, (double x, double y) c)
        {
            return Math.Sign((a.x - c.x) * (b.y - c.y) - (a.y - c.y) * (b.x - c.x));
        }
    }
}

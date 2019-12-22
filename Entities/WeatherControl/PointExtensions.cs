using System;

namespace Entities.WeatherControl
{
    public static class PointExtensions
    {
        public static (double, double) ToCartesian(this (double radius, double angle) point, int decimalPrecision)
        {
            return (Math.Round(point.radius * Math.Cos(point.angle * Math.PI / 180), decimalPrecision), Math.Round(point.radius * Math.Sin(point.angle * Math.PI / 180), decimalPrecision));
        }

        public static double Distance(this (double x, double y) a, (double x, double y) b, int decimalPrecision)
        {
            return Math.Round(Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.y - a.y), 2)), decimalPrecision);
        }
    }
}

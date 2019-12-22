using System;

namespace Entities.WeatherControl
{
    public static class PointExtensions
    {
        public static double Distance(this (double x, double y) a, (double x, double y) b, int decimalPrecision)
        {
            return Math.Round(Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.y - a.y), 2)), decimalPrecision);
        }
    }
}

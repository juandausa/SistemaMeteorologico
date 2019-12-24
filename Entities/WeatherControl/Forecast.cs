using System;

namespace Entities.WeatherControl
{
    public class Forecast
    {
        public Weather Weather { get; }
        public uint Day { get; }
        public double RainfallIntensity { get; }

        protected Forecast(uint day, Weather weather, double rainfallIntensity)
        {
            if (day == 0)
            {
                throw new ArgumentException(nameof(day));
            }

            this.Day = day;
            this.Weather = weather;
            this.RainfallIntensity = rainfallIntensity;
        }

        public Forecast(uint day, double rainfallIntensity) : this(day, Weather.Rainy, rainfallIntensity) { }

        public Forecast(uint day, Weather weather) : this(day, weather, 0)
        {
        }
    }
}

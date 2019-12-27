using API.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.WeatherControl
{
    public class Forecast : EntityBase
    {
        [Required]
        public Weather Weather { get; set; }
        [Required]
        public uint Day { get; set; }
        [Required]
        public double RainfallIntensity { get; set; }

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

        public Forecast() { }

        public Forecast(uint day, double rainfallIntensity) : this(day, Weather.Rainy, rainfallIntensity) { }

        public Forecast(uint day, Weather weather) : this(day, weather, 0)
        {
        }
    }
}

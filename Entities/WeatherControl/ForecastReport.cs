using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.WeatherControl
{
    public class ForecastReport
    {
        public IList<Forecast> Forecasts { get; }
        public IDictionary<Weather, uint> Periods { get; }
        public uint HeaviestDayOfRain { get; protected set; }

        public ForecastReport(IList<Forecast> forecasts)
        {
            if (forecasts == null || !forecasts.Any())
            {
                throw new ArgumentNullException(nameof(forecasts));
            }

            this.Forecasts = forecasts;
            this.Periods = new Dictionary<Weather, uint>();
            this.GenerateReport();
        }

        protected virtual void GenerateReport()
        {
            foreach (var weatherCondition in (Weather[])Enum.GetValues(typeof(Weather)))
            {
                this.Periods.Add(weatherCondition, 0);
            }

            var lastWeather = this.Forecasts.First().Weather;
            this.Periods[lastWeather] += 1;

            foreach (var forecast in this.Forecasts)
            {
                if (forecast.Weather != lastWeather)
                {
                    this.Periods[forecast.Weather] += 1;
                }

                lastWeather = forecast.Weather;
            }

            this.Forecasts.Where(forecast => forecast.Weather == Weather.Rainy).WhereResponse().Success(rainyDays =>
            {
                this.HeaviestDayOfRain = rainyDays.Where(forecast => forecast.RainfallIntensity == rainyDays.Max(forecastHeaviestRainfall => forecastHeaviestRainfall.RainfallIntensity)).First().Day;
            });
        }
    }
}

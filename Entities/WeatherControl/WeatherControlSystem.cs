using System.Collections.Generic;

namespace Entities.WeatherControl
{
    public class WeatherControlSystem
    {
        public SolarSystem.SolarSystem SolarSystem { get; }

        public WeatherControlSystem(SolarSystem.SolarSystem solarSystem)
        {
            this.SolarSystem = solarSystem ?? throw new System.ArgumentNullException(nameof(solarSystem));
        }

        public IList<Forecast> CalculateForecast(uint amountOfDays)
        {
            var forecasts = new List<Forecast>();

            for (uint day = 1; day <= amountOfDays; day++)
            {
                forecasts.Add(this._CalculateForecast(day));
            }

            return forecasts;
        }

        protected virtual Forecast _CalculateForecast(uint day)
        {
            return new Forecast()
            {
                Day = day,
                Weather = Weather.Drought
            };
        }
    }
}

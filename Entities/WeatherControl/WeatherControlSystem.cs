using System;
using System.Collections.Generic;

namespace Entities.WeatherControl
{
    public class WeatherControlSystem
    {
        public SolarSystem.SolarSystem SolarSystem { get; set; }

        public WeatherControlSystem(SolarSystem.SolarSystem solarSystem)
        {
            this.SolarSystem = solarSystem ?? throw new System.ArgumentNullException(nameof(solarSystem));
        }

        public IList<Forecast> CalculateForecast(uint amountOfDays)
        {
            for (var day = 0; day < amountOfDays; day++)
            {
                var forecast = this._CalculateForecast(day);
            }

            return new List<Forecast>();
        }

        protected virtual object _CalculateForecast(int day)
        {
            throw new NotImplementedException();
        }
    }
}

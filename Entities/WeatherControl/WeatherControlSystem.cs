using Entities.SolarSystem;
using System.Collections.Generic;
using System.Linq;

namespace Entities.WeatherControl
{
    public class WeatherControlSystem
    {
        public SolarSystem.SolarSystem SolarSystem { get; }
        public int DecimalPresicion { get; }

        public WeatherControlSystem(SolarSystem.SolarSystem solarSystem, int decimalPresicion)
        {
            if (decimalPresicion < 0)
            {
                throw new System.ArgumentException(nameof(solarSystem));
            }

            this.SolarSystem = solarSystem ?? throw new System.ArgumentNullException(nameof(solarSystem));
            this.DecimalPresicion = decimalPresicion;
        }
        public WeatherControlSystem(SolarSystem.SolarSystem solarSystem) : this(solarSystem, 2) { }

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
            var forecast = new Forecast(day, Weather.Other);
            if (this.PlanetsAlignedWithSun(day))
            {
                forecast.Weather = Weather.Drought;
                return forecast;
            }

            if (this.PlanetsAligned(day))
            {
                forecast.Weather = Weather.Normal;
                return forecast;
            }

            return forecast;
        }

        protected virtual bool PlanetsAlignedWithSun(uint day)
        {
            Line line = CreateLineBetweenFirstAndLasPlanet(day);
            return this.SolarSystem.Planets.All(planet => line.Contains(GetCartesianPosition(day, planet))) && line.Contains(this.SolarSystem.SunPosition);
        }

        protected virtual bool PlanetsAligned(uint day)
        {
            Line line = CreateLineBetweenFirstAndLasPlanet(day);
            return this.SolarSystem.Planets.All(planet => line.Contains(GetCartesianPosition(day, planet)));
        }

        private Line CreateLineBetweenFirstAndLasPlanet(uint day)
        {
            var firstPlanet = this.SolarSystem.Planets.First();
            var lastPlanet = this.SolarSystem.Planets.Last();
            var line = new Line(GetCartesianPosition(day, firstPlanet), GetCartesianPosition(day, lastPlanet));
            return line;
        }

        protected virtual (double, double) GetCartesianPosition(uint day, Planet lastPlanet)
        {
            return (lastPlanet.SunDistance, lastPlanet.GetAngle(day)).ToCartesian(this.DecimalPresicion);
        }
    }
}

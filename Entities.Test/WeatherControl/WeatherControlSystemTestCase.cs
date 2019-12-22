using Entities.SolarSystem;
using Entities.WeatherControl;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Entities.Test.WeatherControl
{
    public class WeatherControlSystemTestCase
    {
        [Fact]
        public void SolarSystem_GetTomorrowForecast_ReturnForecastReportWithOneElement()
        {
            var earth = new Planet("Earth", 1000, 0);
            var mars = new Planet("Mars", 2000, 0);
            var neptune = new Planet("Neptune", 3000, 0);
            var planets = new List<Planet>() { earth, mars, neptune };

            var solarSystem = new Entities.SolarSystem.SolarSystem(planets);
            var weatherControlSystem = new WeatherControlSystem(solarSystem);
            var forecast = weatherControlSystem.CalculateForecast(1);
            forecast.Count.Should().Be(1);
        }

        [Fact]
        public void DroughtSeasonSolarSystem_GetForecast_ReturnDroughtSeason()
        {
            var earth = new Planet("Earth", 1000, 0);
            var mars = new Planet("Mars", 2000, 0);
            var neptune = new Planet("Neptune", 3000, 0);
            var planets = new List<Planet>() { earth, mars, neptune };

            var solarSystem = new Entities.SolarSystem.SolarSystem(planets);
            var weatherControlSystem = new WeatherControlSystem(solarSystem);
            var forecast = weatherControlSystem.CalculateForecast(1);
            forecast.First().Day.Should().Be(1);
            forecast.First().Weather.Should().Be(Weather.Drought);
        }

        [Fact]
        public void NormalSeasonSolarSystem_GetForecast_ReturnNormalSeason()
        {
            var earth = new Planet("Earth", 1000, 45);
            var mars = new Planet("Mars", 1000, 45);
            var neptune = new Planet("Neptune", 1000, -45);
            var planets = new List<Planet>() { earth, mars, neptune };

            var solarSystem = new Entities.SolarSystem.SolarSystem(planets);
            var weatherControlSystem = new WeatherControlSystem(solarSystem);
            var forecast = weatherControlSystem.CalculateForecast(1);
            forecast.First().Day.Should().Be(1);
            forecast.First().Weather.Should().Be(Weather.Normal);
        }
    }
}

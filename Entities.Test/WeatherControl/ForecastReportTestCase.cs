using Entities.WeatherControl;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Entities.Test.WeatherControl
{
    public class ForecastReportTestCase
    {
        [Fact]
        public void OneDayForecast_GenerateReport_ReturnOnePeriod()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, Weather.Normal),
            };

            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(1);
            report.Periods[Weather.Normal].Should().Be(1);
        }

        [Fact]
        public void OneDayOfRainyForecast_GenerateReport_ReturnOnePeriod()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, Weather.Rainy),
            };

            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(1);
            report.Periods[Weather.Rainy].Should().Be(1);
        }

        [Fact]
        public void OneDayOfOtherForecast_GenerateReport_ReturnOnePeriod()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, Weather.Other),
            };

            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(1);
            report.Periods[Weather.Other].Should().Be(1);
        }

        [Fact]
        public void OneDayOfOtherForecast_GenerateReport_ReturnNoHeaviestDayOfRain()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, Weather.Other),
            };

            var report = new ForecastReport(forecast);
            report.HeaviestDayOfRain.Should().Be(0);
        }

        [Fact]
        public void OneDayOfNormalForecast_GenerateReport_ReturnNoHeaviestDayOfRain()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, Weather.Normal),
            };

            var report = new ForecastReport(forecast);
            report.HeaviestDayOfRain.Should().Be(0);
        }

        [Fact]
        public void OneDayOfDroughtForecast_GenerateReport_ReturnNoHeaviestDayOfRain()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, Weather.Drought),
            };

            var report = new ForecastReport(forecast);
            report.HeaviestDayOfRain.Should().Be(0);
        }

        [Fact]
        public void OneDayOfRainyForecast_GenerateReport_ReturnHeaviestDayOfRain()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, Weather.Rainy),
            };

            var report = new ForecastReport(forecast);
            report.HeaviestDayOfRain.Should().Be(1);
        }

        [Fact]
        public void OneDayOfRainyAndOneOfDrouthForecast_GenerateReport_ReturnTwoPeriods()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, 321),
                new Forecast(2, Weather.Drought),
            };

            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(2);
            report.Periods[Weather.Rainy].Should().Be(1);
            report.Periods[Weather.Drought].Should().Be(1);
        }

        [Fact]
        public void OneDayOfRainyAndOneOfNormalForecast_GenerateReport_ReturnTwoPeriods()
        {
            var forecast = new List<Forecast>()
            {
                new Forecast(1, 325),
                new Forecast(2, Weather.Normal),
            };

            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(2);
            report.Periods[Weather.Rainy].Should().Be(1);
            report.Periods[Weather.Normal].Should().Be(1);
        }

        [Fact]
        public void TenDaysOfRainyAndOneOfNormalForecast_GenerateReport_ReturnTwoPeriods()
        {
            List<Forecast> forecast = CreateTenDaysOfRain();
            forecast.Add(new Forecast(11, Weather.Normal));
            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(2);
            report.Periods[Weather.Rainy].Should().Be(1);
            report.Periods[Weather.Normal].Should().Be(1);
        }

        [Fact]
        public void TwoPeriodsOfRainyAndOneOfNormalForecast_GenerateReport_ReturnPeriods()
        {
            List<Forecast> forecast = CreateTenDaysOfRain();
            forecast.Add(new Forecast(11, Weather.Normal));
            forecast.Add(new Forecast(12, 100));
            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(2);
            report.Periods[Weather.Rainy].Should().Be(2);
            report.Periods[Weather.Normal].Should().Be(1);
        }

        [Fact]
        public void TwoPeriodsOfRainyOneOfNormalOneOfDroughtAndOneOfOtherForecast_GenerateReport_ReturnPeriods()
        {
            List<Forecast> forecast = CreateTenDaysOfRain();
            forecast.Add(new Forecast(11, Weather.Normal));
            forecast.Add(new Forecast(12, 100));
            forecast.Add(new Forecast(13, Weather.Drought));
            forecast.Add(new Forecast(14, Weather.Other));
            var report = new ForecastReport(forecast);
            report.Periods.Values.Any(value => value > 0).Should().BeTrue();
            report.Periods.Values.Count(value => value > 0).Should().Be(4);
            report.Periods[Weather.Rainy].Should().Be(2);
            report.Periods[Weather.Normal].Should().Be(1);
            report.Periods[Weather.Drought].Should().Be(1);
            report.Periods[Weather.Other].Should().Be(1);
        }

        private static List<Forecast> CreateTenDaysOfRain()
        {
            var forecast = new List<Forecast>();
            for (uint i = 1; i < 10; i++)
            {
                forecast.Add(new Forecast(i, i + 200));
            }

            return forecast;
        }
    }
}

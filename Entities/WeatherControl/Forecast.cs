namespace Entities.WeatherControl
{
    public class Forecast
    {
        public Weather Weather { get; set; }
        public uint Day { get; set; }
        public double RainfallIntensity { get; set; }

        public Forecast(uint day, Weather weather, double rainfallIntensity)
        {
            this.Day = day;
            this.Weather = weather;
            this.RainfallIntensity = rainfallIntensity;
        }

        public Forecast(uint day, Weather weather) : this(day, weather, 0)
        {
        }
    }
}

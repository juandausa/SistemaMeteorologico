namespace Entities.WeatherControl
{
    public class Forecast
    {
        public Weather Weather { get; set; }
        public uint Day { get; set; }

        public Forecast(uint day, Weather weather)
        {
            Day = day; this.Weather = weather;
        }
    }
}

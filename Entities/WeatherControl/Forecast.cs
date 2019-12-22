namespace Entities.WeatherControl
{
    public class Forecast
    {
        public Forecast(uint day)
        {
            Day = day;
        }

        public Weather Weather { get; set; }
        public uint Day { get; set; }
    }
}

using Entities.WeatherControl;

namespace HwEFCoreWebAPI.Contracts
{
    public class ForecastDataContract
    {
        public ForecastDataContract() { }
        public ForecastDataContract(Forecast forecast)
        {
            this.Dia = forecast.Day;
            this.Clima = forecast.Weather;
        }

        public uint Dia { get; set; }
        public Weather Clima { get; set; }
    }
}

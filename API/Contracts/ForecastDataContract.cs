using System;
using Entities.WeatherControl;

namespace HwEFCoreWebAPI.Contracts
{
    public class ForecastDataContract
    {
        public ForecastDataContract() { }
        public ForecastDataContract(Forecast forecast)
        {
            this.Dia = forecast.Day;
            this.Clima = forecast.Weather.Description();
        }

        public uint Dia { get; set; }
        public string Clima { get; set; }
    }
}

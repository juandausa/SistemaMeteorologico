using System.ComponentModel;

namespace Entities.WeatherControl
{
    public enum Weather
    {
        [Description("sequia")]
        Drought = 0,
        [Description("lluvia")]
        Rainy = 1,
        [Description("condiciones normales de presión y temperatura")]
        Normal = 2,
        [Description("otro")]
        Other = 3
    }
}

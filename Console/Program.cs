using Entities.WeatherControl;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Se generará el pronóstico para 3650 días para el sistema compuesto por: ");
            System.Console.WriteLine("- Ferengi, que se desplaza con una velocidad angular de 1 grados/día en sentido horario y su distancia con respecto al sol es de 500Km");
            System.Console.WriteLine("- Betasoide, que se desplaza con una velocidad angular de 3 grados/día en sentido horario y su distancia con respecto al sol es de 2000Km.");
            System.Console.WriteLine("- Vulcano, que se desplaza con una velocidad angular de 5 grados/día en sentido anti­horario y su distancia con respecto al sol es de 1000Km.");

            var report = new ForecastReport(new WeatherControlSystem(Factory.GenerateSolarSystem()).CalculateForecast(3650));

            System.Console.WriteLine("Se encontraron {0} períodos de sequía.", report.Periods[Weather.Drought]);
            System.Console.WriteLine("Se encontraron {0} períodos de lluvia.", report.Periods[Weather.Rainy]);
            System.Console.WriteLine("El día pico de lluvia será el {0}.", report.HeaviestDayOfRain);
            System.Console.WriteLine("Se encontraron {0} períodos de condiciones normales de presión y temperatura.", report.Periods[Weather.Normal]);
            System.Console.ReadLine();
        }
    }
}

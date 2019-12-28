using Entities.SolarSystem;
using System.Collections.Generic;

namespace Console
{
    public static class Factory
    {
        public static SolarSystem GenerateSolarSystem()
        {
            var ferengi = new Planet("Ferengi", 1, 500);
            var betasoide = new Planet("Betasoide", 3, 2000);
            var vulcano = new Planet("Vulcano", -5, 1000);

            return new SolarSystem(new List<Planet>() { ferengi, betasoide, vulcano });
        }

    }
}

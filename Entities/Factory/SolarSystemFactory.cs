using Entities.SolarSystem;
using System.Collections.Generic;

namespace Entities.Factory
{
    public static class SolarSystemFactory
    {
        public static SolarSystem.SolarSystem GenerateSolarSystem()
        {
            var ferengi = new Planet("Ferengi", 1, 500);
            var betasoide = new Planet("Betasoide", 3, 2000);
            var vulcano = new Planet("Vulcano", -5, 1000);

            return new SolarSystem.SolarSystem(new List<Planet>() { ferengi, betasoide, vulcano });
        }

    }
}

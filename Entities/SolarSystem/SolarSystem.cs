using System.Collections.Generic;

namespace Entities.SolarSystem
{
    public class SolarSystem
    {
        public (double, double) SunPosition { get; }
        public IList<Planet> Planets { get; }

        public SolarSystem(IList<Planet> planets) : this(planets, (0, 0)) { }

        public SolarSystem(IList<Planet> planets, (double x, double y) sunPosition)
        {
            if (planets == null || planets.Count < 2)
            {
                new System.ArgumentException(nameof(planets));
            }

            this.Planets = planets;
            this.SunPosition = sunPosition;
        }
    }
}

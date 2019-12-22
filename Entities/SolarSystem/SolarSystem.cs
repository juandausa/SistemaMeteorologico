using System.Collections.Generic;

namespace Entities.SolarSystem
{
    public class SolarSystem
    {
        public (double, double) SunPosition { get; }
        public IList<Planet> Planets { get; }
        public int DecimalPresicion { get; }

        public SolarSystem(IList<Planet> planets) : this(planets, 2) { }

        public SolarSystem(IList<Planet> planets, int decimalPresicion) : this(planets, decimalPresicion, (0, 0)) { }

        public SolarSystem(IList<Planet> planets, int decimalPresicion, (double x, double y) sunPosition)
        {
            if (planets == null || planets.Count < 2)
            {
                new System.ArgumentException(nameof(planets));
            }

            if (decimalPresicion == 0)
            {
                new System.ArgumentException(nameof(decimalPresicion));
            }

            this.Planets = planets;
            this.DecimalPresicion = decimalPresicion;
            this.SunPosition = sunPosition;
        }
    }
}

using System.Collections.Generic;

namespace Entities.SolarSystem
{
    public class SolarSystem
    {
        public IList<Planet> Planets { get; }
        public int DecimalPresicion { get; }

        public SolarSystem(IList<Planet> planets) : this(planets, 2) { }

        public SolarSystem(IList<Planet> planets, int decimalPresicion)
        {
            if (decimalPresicion == 0)
            {
                new System.ArgumentException(nameof(decimalPresicion));
            }

            this.Planets = planets ?? throw new System.ArgumentNullException(nameof(planets));
            this.DecimalPresicion = decimalPresicion;
        }
    }
}

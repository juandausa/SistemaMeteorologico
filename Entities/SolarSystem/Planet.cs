namespace Entities.SolarSystem
{
    public class Planet
    {
        public string Name { get; }
        public double Velocity { get; }
        public double SunDistance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Planet"/> class.
        /// </summary>
        /// <param name="name">Planet name.</param>
        /// <param name="sunDistance">Distance to the sun (Km).</param>
        /// <param name="velocity">Angular velocity (degree/day).</param>
        public Planet(string name, double sunDistance, double velocity)
        {
            this.Name = name ?? throw new System.ArgumentNullException(nameof(name));
            this.SunDistance = sunDistance;
            this.Velocity = velocity;
        }

        public double GetAngle(uint day)
        {
            return ((this.Velocity * day % 360) + 360) % 360;
        }
    }
}

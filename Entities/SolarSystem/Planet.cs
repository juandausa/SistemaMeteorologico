namespace Entities.SolarSystem
{
    public class Planet
    {
        public string Name { get; }
        public double Velocity { get; }
        public double SunDistance { get; }

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

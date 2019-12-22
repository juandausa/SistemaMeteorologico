namespace Entities.SolarSystem
{
    public class Planet
    {
        public string Name { get; }
        public decimal Velocity { get; }
        public decimal SunDistance { get; }

        public Planet(string name, decimal sunDistance, decimal velocity)
        {
            this.Name = name ?? throw new System.ArgumentNullException(nameof(name));
            this.SunDistance = sunDistance;
            this.Velocity = velocity;
        }

        public decimal GetPosition(uint day)
        {
            return ((this.Velocity * day % 360) + 360) % 360;
        }
    }
}

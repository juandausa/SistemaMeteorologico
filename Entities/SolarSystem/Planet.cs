namespace Entities.SolarSystem
{
    public class Planet
    {
        public Planet(string name, decimal sunDistance, decimal velocity)
        {
            this.Name = name;
            this.SunDistance = sunDistance;
            this.Velocity = velocity;
        }

        public string Name { get; set; }
        public decimal Velocity { get; set; }
        public decimal SunDistance { get; set; }

        public decimal GetPosition(uint day)
        {
            return ((this.Velocity * day % 360) + 360) % 360;
        }
    }
}

using Entities.SolarSystem;
using FluentAssertions;
using Xunit;

namespace Entities.Test.SolarSystem
{
    public class PlanetTestCase
    {
        [Fact]
        public void PlanetWithVelocity_GetInitialPosition_ReturnInitialPosition()
        {
            var planet = new Planet("Earth", 5000, 1);
            planet.GetPosition(0).Should().Be(0);
        }

        [Fact]
        public void SteadyPlanet_GetPosition_ReturnInitialPosition()
        {
            var planet = new Planet("Earth", 5000, 0);
            planet.GetPosition(0).Should().Be(0);
            planet.GetPosition(10).Should().Be(0);
            planet.GetPosition(20).Should().Be(0);
        }

        [Fact]
        public void PlanetWithVelocity_GetPosition_ReturnPosition()
        {
            var planet = new Planet("Earth", 5000, 1);
            planet.GetPosition(5).Should().Be(5);
            planet.GetPosition(50).Should().Be(50);
            planet.GetPosition(361).Should().Be(1);
        }

        [Fact]
        public void PlanetWithNegativeVelocity_GetPosition_ReturnPosition()
        {
            var planet = new Planet("Earth", 5000, -1);
            planet.GetPosition(1).Should().Be(359);
            planet.GetPosition(10).Should().Be(350);
            planet.GetPosition(359).Should().Be(1);
            planet.GetPosition(359 + 360 * 7).Should().Be(1);
        }
    }
}

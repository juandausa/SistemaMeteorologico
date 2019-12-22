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
    }
}

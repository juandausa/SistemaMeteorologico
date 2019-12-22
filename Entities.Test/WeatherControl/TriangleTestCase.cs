using Entities.WeatherControl;
using FluentAssertions;
using Xunit;

namespace Entities.Test.WeatherControl
{
    public class TriangleTestCase
    {
        [Fact]
        public void CreateTriangle_ReturnNoNull()
        {
            Triangle triangle = new Triangle((-4, -3), (-1, 4), (6, 1));
            triangle.Should().NotBeNull();
        }


        [Fact]
        public void TriangleWithOriginInside_ContainsOrigin_ReturnTrue()
        {

            Triangle triangle = new Triangle((-4, -3), (-1, 4), (6, 1));
            triangle.Contains((0, 0)).Should().BeTrue();
            triangle.Contains((-11, 9)).Should().BeFalse();
        }

        [Fact]
        public void TriangleWithOriginInside_NotContains533_ReturnFalse()
        {

            Triangle triangle = new Triangle((-4, -3), (-1, 4), (6, 1));
            triangle.Contains((5, 33)).Should().BeFalse();
        }

        [Fact]
        public void Triangle_ContainsVertex_ReturnTrue()
        {

            Triangle triangle = new Triangle((-4, -3), (-1, 4), (6, 1));
            triangle.Contains((-4, -3)).Should().BeTrue();
            triangle.Contains((-1, 4)).Should().BeTrue();
            triangle.Contains((6, 1)).Should().BeTrue();
        }

        [Fact]
        public void Triangle_GetPerimeter_ReturnPerimeter()
        {
            var triangle = new Triangle((1, 1), (3, 4), (9, 2), 4);
            triangle.Perimeter.Should().Be(17.9925);
        }

        [Fact]
        public void TrianglesWithSameVertex_GetPerimeter_ReturnPerimeter()
        {
            var triangle = new Triangle((6, 0), (0, 0), (3, 3), 4);
            triangle.Perimeter.Should().Be(14.4852);

            var anotherTriangle = new Triangle((0, 0), (3, 3), (6, 0), 4);
            anotherTriangle.Perimeter.Should().Be(14.4852);
        }
    }
}

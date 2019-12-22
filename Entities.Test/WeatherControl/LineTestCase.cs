using Entities.WeatherControl;
using FluentAssertions;
using Xunit;

namespace Entities.Test.WeatherControl
{
    public class LineTestCase
    {

        [Fact]
        public void CreateLine_ReturnLine()
        {
            Line line = new Line((0, 0), (1, 1));
            line.DecimalPrecision.Should().Be(2);
            line.Slope.Should().Be(1);
            line.YIntercept.Should().Be(0);
        }


        [Fact]
        public void CreateLineWithNegativeSlopeAndYIntercept_ReturnLine()
        {
            Line line = new Line((-1, -1), (5, -5));
            line.Slope.Should().Be(-0.67);
            line.YIntercept.Should().Be(-1.67);
        }


        [Fact]
        public void CreateLineWithNegativeSlope_ReturnLine()
        {
            Line line = new Line((0, 0), (-5, 5));
            line.Slope.Should().Be(-1);
            line.YIntercept.Should().Be(0);
        }


        [Fact]
        public void CreateVerticalLineInOrigin_ReturnLine()
        {
            Line line = new Line((0, 0), (0, 5));
            line.Slope.Should().Be(double.PositiveInfinity);
            line.YIntercept.Should().Be(0);
        }

        [Fact]
        public void CreateVerticalLine_ReturnLine()
        {
            Line line = new Line((1, 0), (1, 5));
            line.Slope.Should().Be(double.PositiveInfinity);
            line.YIntercept.Should().Be(double.NaN);
        }

        [Fact]
        public void CreateHorizontalLineInOrigin_ReturnLine()
        {
            Line line = new Line((1, 0), (41, 0));
            line.Slope.Should().Be(0);
            line.YIntercept.Should().Be(0);
        }

        [Fact]
        public void CreateHorizontalLine_ReturnLine()
        {
            Line line = new Line((-1, 2), (1, 2));
            line.Slope.Should().Be(0);
            line.YIntercept.Should().Be(2);
        }

        [Fact]
        public void HorizontalLineInOrigin_CointainsOrigin_ReturnTrue()
        {
            Line line = new Line((1, 0), (41, 0));
            line.Contains((0, 0)).Should().BeTrue();
        }

        [Fact]
        public void HorizontalLineWithYIntercept_CointainsOrigin_ReturnFalse()
        {
            Line line = new Line((1, 1), (41, 1));
            line.Contains((0, 0)).Should().BeFalse();
        }

        [Fact]
        public void VerticalLineInOrigin_CointainsOrigin_ReturnTrue()
        {
            Line line = new Line((0, 0), (0, 41));
            line.Contains((0, 0)).Should().BeTrue();
        }

        [Fact]
        public void VerticalLineWithXIntercept_CointainsOrigin_ReturnFalse()
        {
            Line line = new Line((1, 1), (1, 41));
            line.Contains((0, 0)).Should().BeFalse();
        }


        [Fact]
        public void SeveralPointAligned_Contains_ReturnTrue()
        {
            Line line = new Line((0.0, -1.5), (2.0, 2.5));
            line.Contains((5, 8.5)).Should().BeTrue();
            line.Contains((-1, -3.5)).Should().BeTrue();
            line.Contains((0, 0)).Should().BeFalse();
        }
    }
}

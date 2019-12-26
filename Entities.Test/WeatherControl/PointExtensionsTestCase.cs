using Entities.WeatherControl;
using FluentAssertions;
using Xunit;

namespace Entities.Test.WeatherControl
{
    public class PointExtensionsTestCase
    {
        [Fact]
        public void SamePoint_Distance_RetuenZero()
        {
            (double, double) pointA = (1, 1);
            pointA.Distance(pointA, 2).Should().Be(0);
        }

        [Fact]
        public void TwoPoints_Distance_RetuenSameDistance()
        {
            (double, double) pointA = (1, 1);
            (double, double) pointB = (1, 2);
            pointA.Distance(pointB, 2).Should().Be(1);
            pointB.Distance(pointA, 2).Should().Be(1);
        }

        [Fact]
        public void CircleCenteredAtTheOrigin_Distance_ReturnSameDistance()
        {
            (double, double) pointA = (0, 0);
            (double, double) pointB = (3, 0);
            (double, double) pointC = (0, 3);
            (double, double) pointD = (-3, 0);
            (double, double) pointE = (0, -3);

            pointA.Distance(pointB, 2).Should().Be(3);
            pointA.Distance(pointC, 2).Should().Be(3);
            pointA.Distance(pointD, 2).Should().Be(3);
            pointA.Distance(pointE, 2).Should().Be(3);
        }

        [Fact]
        public void Origin_ToCartesian_ReturnOrigin()
        {
            (double, double) radian = (0, 0);
            radian.ToCartesian(2).Item1.Should().Be(0);
            radian.ToCartesian(2).Item2.Should().Be(0);
        }

        [Fact]
        public void PointAt0DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 0);
            radian.ToCartesian(2).Item1.Should().Be(1);
            radian.ToCartesian(2).Item2.Should().Be(0);
        }

        [Fact]
        public void PointAt45DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 45);
            radian.ToCartesian(2).Item1.Should().Be(0.71);
            radian.ToCartesian(2).Item2.Should().Be(0.71);
        }

        [Fact]
        public void PointAt90DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 90);
            radian.ToCartesian(2).Item1.Should().Be(0);
            radian.ToCartesian(2).Item2.Should().Be(1);
        }

        [Fact]
        public void PointAt135DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 135);
            radian.ToCartesian(2).Item1.Should().Be(-0.71);
            radian.ToCartesian(2).Item2.Should().Be(0.71);
        }

        [Fact]
        public void PointAt180DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 180);
            radian.ToCartesian(2).Item1.Should().Be(-1);
            radian.ToCartesian(2).Item2.Should().Be(0);
        }

        [Fact]
        public void PointAt225DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 225);
            radian.ToCartesian(2).Item1.Should().Be(-0.71);
            radian.ToCartesian(2).Item2.Should().Be(-0.71);
        }

        [Fact]
        public void PointAt270DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 270);
            radian.ToCartesian(2).Item1.Should().Be(0);
            radian.ToCartesian(2).Item2.Should().Be(-1);
        }

        [Fact]
        public void PointAt315DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 315);
            radian.ToCartesian(2).Item1.Should().Be(0.71);
            radian.ToCartesian(2).Item2.Should().Be(-0.71);
        }

        [Fact]
        public void PointAt360DegreesAndRadiusOne_ToCartesian_Return()
        {
            (double, double) radian = (1, 360);
            radian.ToCartesian(2).Item1.Should().Be(1);
            radian.ToCartesian(2).Item2.Should().Be(0);
        }
    }
}

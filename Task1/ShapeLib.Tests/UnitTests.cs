using System;
using Xunit;
using ShapeLib.Shapes;
using ShapeLib.Interfaces;
using System.Collections.Generic;
using static ShapeLib.Helpers.MathFCompat;

namespace ShapeLib.Tests
{
    public class UnitTests
    {
        public static List<object[]> Shapes = new List<object[]>()
        {
            new object[]{ new Triangle(3, 4, 5), 6f},
            new object[]{ new Circle(1 / MathF.Sqrt(Pi)), 1f}
        };

        [Theory]
        [MemberData(nameof(Shapes))]
        public void CalculateArea_ShapeOk_ReturnsCorrectArea(IShape shape, float expected)
        {
            var actual = shape.CalculateArea();
            Assert.True(ApproximatelyEquals(actual, expected));
        }

        [Theory]
        [Repeat(500)]
        public void CalculateArea_UnknownCompileTime_ReturnsCorrectArea(int iteration)
        {
            var rnd = new Random(iteration);
            var coinFlip = rnd.Next(2);
            var shape = (IShape)Shapes[coinFlip][0];
            var expected = (float)Shapes[coinFlip][1];

            var actual = shape.CalculateArea();
            Assert.True(ApproximatelyEquals(actual, expected));
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(2, 4, 5, false)]
        public void IsTriangleRight(float a, float b, float c, bool expected)
        {
            var triangle = new Triangle(a, b, c);
            var actual = triangle.IsRight;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ApproximatelyEquals_FloatPrecisionError_Ignored()
        {
            Assert.True(ApproximatelyEquals(1f, 3f / MathF.Sqrt(3f) / MathF.Sqrt(3f)));
            Assert.NotEqual(1f, 3f / MathF.Sqrt(3f) / MathF.Sqrt(3f));
        }
    }
}

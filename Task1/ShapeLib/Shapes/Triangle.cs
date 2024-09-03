using System;
using ShapeLib.Interfaces;
using static ShapeLib.Helpers.MathFCompat;

namespace ShapeLib.Shapes
{
    public class Triangle : IShape
    {
        private readonly float _a, _b, _c;

        public bool IsRight => ApproximatelyEquals(_a * _a + _b * _b, _c * _c);

        public Triangle(float a, float b, float c)
        {
            var sides = new float[] { a, b, c };
            Array.Sort(sides);

            if (sides[0] <= 0)
                throw new ArgumentException("No side should be less than or equal to 0.");

            if (sides[0] + sides[1] <= sides[2])
                throw new ArgumentException("Triangle with these sides is not possible.");

            _a = sides[0];
            _b = sides[1];
            _c = sides[2];
        }

        public float CalculateArea()
        {
            //Herons formula
            var s = 0.5f * (_a + _b + _c);
            return MathF.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
        }
    }
}

using System;
using ShapeLib.Interfaces;
using static ShapeLib.Helpers.MathFCompat;

namespace ShapeLib.Shapes
{
    public class Circle : IShape
    {
        public float Radius { get; set; }

        public Circle(float radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius must be >= 0");
            Radius = radius;
        }

        public float CalculateArea()
        {
            return Pi * Radius * Radius;
        }
    }
}

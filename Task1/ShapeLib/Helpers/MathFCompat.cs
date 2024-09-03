using static System.Math;

namespace ShapeLib.Helpers
{
    public static class MathFCompat
    {
        public const float Pi = (float)PI;

        //Taken from https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Math/Mathf.cs#L281
        public static bool ApproximatelyEquals(float a, float b)
        {
            return Abs(b - a) < Max(1e-6f * Max(Abs(a), Abs(b)), float.Epsilon * 8);
        }
    }
}

namespace Albelli.Impose.DataModel.Extensions
{
    public static class UnitsExtensions
    {
        private const float PointsInInch = 72.0f;
        private const float PointsInMm = 2.83464388f;

        public static float MmToPoints(this float mmValue)
        {
            return mmValue * PointsInMm;
        }

        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this int value)
        {
            return value % 2 == 1;
        }
    }
}
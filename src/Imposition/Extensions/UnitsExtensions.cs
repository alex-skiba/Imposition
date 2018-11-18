namespace Imposition.Extensions
{
    public static class UnitsExtensions
    {
        private const float PointsInInch = 72.0f;
        private const float PointsInMm = 2.83464388f;

        public static float MmToPoints(this float mmValue)
        {
            return mmValue * PointsInMm;
        }
    }
}
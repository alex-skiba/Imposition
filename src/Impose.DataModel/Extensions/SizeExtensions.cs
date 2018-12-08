using System;
using Albelli.Impose.DataModel.Common;

namespace Albelli.Impose.DataModel.Extensions
{
    public static class SizeExtensions
    {
        public static bool EqualTo(this Size source, Size other, float comparisonTolerance)
        {
            return Math.Abs(source.Width - other.Width) <= comparisonTolerance && Math.Abs(source.Height - other.Height) <= comparisonTolerance;
        }

        public static bool EqualTo(this Size source, Size other)
        {
            return source.EqualTo(other, 0.0f);
        }
    }
}
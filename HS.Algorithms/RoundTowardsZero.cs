using System;

namespace HS.Algorithms
{
    public static class DecimalExtensions
    {
        public static decimal RoundTowardsZero(this decimal d, int places)
        {
            if (places < 0)
                throw new ArgumentOutOfRangeException("places", places, "Must be >= 0");

            var m = (decimal)Math.Pow(10, places);
            var truncated = Math.Truncate(d * m);

            return (Math.Abs((d * m) - truncated) > 0.5m)
                ? Math.Round(d, places, MidpointRounding.AwayFromZero)
                : truncated / m;
        }
    }
}

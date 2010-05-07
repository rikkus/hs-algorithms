using System;
using System.Collections.Generic;

namespace HS.Algorithms.EnumerableExtensions
{
    public static class UnixStyleUniq
    {
        /**
         * Only the first of each group of consecutive identical values from enumerable are yielded.
         * Values are tested for equality using the default comparer on the result of func.
         */
        public static IEnumerable<T> Uniq<T, TComparison>
            (
            this IEnumerable<T> enumerable,
            Func<T, TComparison> func
            )
        {
            return Uniq(enumerable, func, EqualityComparer<TComparison>.Default);
        }

        /**
         * Only the first of each group of consecutive identical values from enumerable are yielded.
         * Values are tested for equality using comparer on the result of func.
         */
        public static IEnumerable<T> Uniq<T, TComparison>
            (
            this IEnumerable<T> enumerable,
            Func<T, TComparison> func,
            IEqualityComparer<TComparison> comparer
            )
        {
            var first = true;
            var lastComparisonValue = default(TComparison);

            foreach (var value in enumerable)
            {
                var comparisonValue = func(value);

                if (first)
                {
                    first = false;
                    lastComparisonValue = comparisonValue;
                    yield return value;
                }
                else
                {
                    if (!comparer.Equals(comparisonValue, lastComparisonValue))
                    {
                        yield return value;
                    }

                    lastComparisonValue = comparisonValue;
                }
            }
        }
    }
}
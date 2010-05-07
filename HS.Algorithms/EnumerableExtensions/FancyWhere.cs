using System;
using System.Collections.Generic;

namespace HS.Algorithms.EnumerableExtensions
{
    public static class FancyWhere
    {
        /*
         * Passes func three values: previous, current and next.
         * 
         * If the null value is xx and the input is [v0], func will be called with values:
         * [xx, v0, xx]
         * 
         * If the null value is xx and the input is [v0, v1], func will be called with values:
         * [xx, v0, v1]
         * [v0, v1, xx]
         * 
         * If the null value is xx and the input is [v0, v1, v2], func will be called with values:
         * [xx, v0, v1]
         * [v0, v1, v2]
         * [v1, v2, xx]
         * 
         * If the null value is xx and the input is [v0, v1, v2, v3], func will be called with values:
         * [xx, v0, v1]
         * [v0, v1, v2]
         * [v1, v2, v3]
         * [v2, v3, xx]
         * 
         * etc.
         */
        public static IEnumerable<T> Where<T>
            (
            this IEnumerable<T> enumerable,
            T nullValue,
            Func<T, T, T, bool> func
            )
        {
            var previousItem = nullValue;
            var currentItem = nullValue;

            var index = 0;

            foreach (var item in enumerable)
            {
                switch (index++)
                {
                    case 0:
                        currentItem = item;
                        break;

                    case 1:
                        previousItem = currentItem;
                        currentItem = item;
                        break;

                    case 2:

                        if (func(nullValue, previousItem, currentItem))
                            yield return previousItem;

                        if (func(previousItem, currentItem, item))
                            yield return currentItem;

                        previousItem = currentItem;
                        currentItem = item;

                        break;

                    default:

                        if (func(previousItem, currentItem, item))
                            yield return currentItem;

                        previousItem = currentItem;
                        currentItem = item;

                        break;
                }
            }

            switch (index)
            {
                case 1:

                    if (func(previousItem, currentItem, nullValue))
                        yield return currentItem;

                    break;

                case 2:

                    if (func(nullValue, previousItem, currentItem))
                        yield return previousItem;

                    if (func(previousItem, currentItem, nullValue))
                        yield return currentItem;

                    break;

                default:

                    if (func(previousItem, currentItem, nullValue))
                        yield return currentItem;

                    break;
            }
        }
    }
}
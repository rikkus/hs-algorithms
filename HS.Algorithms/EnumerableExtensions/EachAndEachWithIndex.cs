using System;
using System.Collections.Generic;

namespace HS.Algorithms.EnumerableExtensions
{
    public static class EachAndEachWithIndex
    {
        public static IEnumerable<TResult> Each<T, TResult>
            (
            this IEnumerable<T> enumerable,
            Func<T, TResult> xFunc,
            Func<T, TResult> xsFunc
            )
        {
            bool first = true;

            foreach (var item in enumerable)
            {
                if (first)
                {
                    first = false;
                    yield return xFunc(item);
                }
                else
                {
                    yield return xsFunc(item);
                }
            }
        }

        public static IEnumerable<TResult> EachWithIndex<T, TResult>
            (
            this IEnumerable<T> enumerable,
            Func<T, TResult> xFunc,
            Func<T, long, TResult> xsFunc
            )
        {
            bool first = true;
            long index = 0;

            foreach (var item in enumerable)
            {
                if (first)
                {
                    first = false;
                    yield return xFunc(item);
                }
                else
                {
                    yield return xsFunc(item, index++);
                }
            }
        }

        public static IEnumerable<TResult> Each<T, TResult>
            (
            this IEnumerable<T> enumerable,
            Func<T, TResult> func
            )
        {
            foreach (var item in enumerable)
            {
                yield return func(item);
            }
        }

        public static IEnumerable<TResult> EachWithIndex<T, TResult>
            (
            this IEnumerable<T> enumerable,
            Func<T, long, TResult> func
            )
        {
            long index = 0;

            foreach (var item in enumerable)
            {
                yield return func(item, index++);
            }
        }

        public static void Each<T>
            (
            this IEnumerable<T> enumerable,
            Action<T> action
            )
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static void EachWithIndex<T>
            (
            this IEnumerable<T> enumerable,
            Action<T, long> action
            )
        {
            long index = 0;

            foreach (var item in enumerable)
            {
                action(item, index++);
            }
        }
    }
}
IEnumerable<T> extensions for direct enumeration without using foreach:

```
IEnumerable<TResult> Each<T, TResult>
(
    this IEnumerable<T> enumerable,
    Func<T, TResult> xFunc,
    Func<T, TResult> xsFunc
)

IEnumerable<TResult> EachWithIndex<T, TResult>
(
    this IEnumerable<T> enumerable,
    Func<T, TResult> xFunc,
    Func<T, long, TResult> xsFunc
)
       
IEnumerable<TResult> Each<T, TResult>
(
    this IEnumerable<T> enumerable,
    Func<T, TResult> func
)

IEnumerable<TResult> EachWithIndex<T, TResult>
(
    this IEnumerable<T> enumerable,
    Func<T, long, TResult> func
)
       
void Each<T>
(
    this IEnumerable<T> enumerable,
    Action<T> action
)
        
void EachWithIndex<T>
(
    this IEnumerable<T> enumerable,
    Action<T, long> action
)

```

IEnumerable<T> extensions for selecting unique values (in the style of uniq(1)):

```
/**
 * Only the first of each group of consecutive identical values from enumerable are yielded.
 * Values are tested for equality using the default comparer on the result of func.
 */
IEnumerable<T> Uniq<T, TComparison>
(
    this IEnumerable<T> enumerable,
    Func<T, TComparison> func
)

/**
 * Only the first of each group of consecutive identical values from enumerable are yielded.
 * Values are tested for equality using comparer on the result of func.
 */
IEnumerable<T> Uniq<T, TComparison>
(
    this IEnumerable<T> enumerable,
    Func<T, TComparison> func,
    IEqualityComparer<TComparison> comparer
)
```

IEnumerable<T> extension to filter items based on comparisons between triples:

```
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
IEnumerable<T> Where<T>
(
    this IEnumerable<T> enumerable,
    T nullValue,
    Func<T, T, T, bool> func
)
```

decimal extensions:

```
decimal RoundTowardsZero(this decimal d, int places)
```

base N codec:

```
var encoded = BaseNCodec.Encode(BigInteger.Parse("12903801239012380128301283"), "abcdefghijklmnopqrstuvwxyz0123456789");
```

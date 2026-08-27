using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// QueryBuilder
/// </summary>
/// <typeparam name="T">Type</typeparam>
public class QueryBuilder<T>
{
    private readonly IEnumerable<T> _query;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
    /// Builds the query
    /// </summary>
    /// <param name="source">source</param>
    public QueryBuilder(IEnumerable<T> source)
    {
        _query = source;
    }

    private QueryBuilder(IEnumerable<T> source, bool _)
    {
        _query = source;
    }

    /// <summary>
    /// Filters
    /// </summary>
    /// <param name="predicate">predicate</param>
    /// <returns>returns</returns>
    public QueryBuilder<T> Filter(Func<T, bool> predicate)
    {
        return new QueryBuilder<T>(
            _query.Where(predicate),
            true);
    }

    /// <summary>
    /// Sorts by
    /// </summary>
    /// <typeparam name="TKey">tkey</typeparam>
    /// <param name="keySelector">keyselctor</param>
    /// <returns>querybuilder</returns>
    public QueryBuilder<T> SortBy<TKey>(
        Func<T, TKey> keySelector)
    {
        return new QueryBuilder<T>(
            _query.OrderBy(keySelector),
            true);
    }

    /// <summary>
    /// Join
    /// </summary>
    /// <typeparam name="TOther">other</typeparam>
    /// <typeparam name="TKey">key</typeparam>
    /// <typeparam name="TResult">result</typeparam>
    /// <param name="otherCollection">collection</param>
    /// <param name="outerKeySelector">keyselector</param>
    /// <param name="innerKeySelector">keyselctor</param>
    /// <param name="resultSelector">selector</param>
    /// <returns>querybuilder</returns>
    public QueryBuilder<TResult> Join<TOther, TKey, TResult>(
        IEnumerable<TOther> otherCollection,
        Func<T, TKey> outerKeySelector,
        Func<TOther, TKey> innerKeySelector,
        Func<T, TOther, TResult> resultSelector)
    {
        return new QueryBuilder<TResult>(
            _query.Join(
                otherCollection,
                outerKeySelector,
                innerKeySelector,
                resultSelector),
            true);
    }

    /// <summary>
    /// Execute
    /// </summary>
    /// <returns>List</returns>
    public List<T> Execute()
    {
        return _query.ToList();
    }
}
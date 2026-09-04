using System.Linq.Expressions;

namespace LanguageInetgratedQuery
{
    /// <summary>
    /// Query Builder
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class QueryBuilder<T>
    {
        private IEnumerable<T> _data;

        private List<Expression<Func<T, bool>>>? _filters =
            new List<Expression<Func<T, bool>>>();

        private Expression<Func<T, object>>? _sortExpression;

        private IEnumerable<T> _joinData =
            new List<T>();

        private Expression<Func<T, string>>? _dataKey;

        private Expression<Func<T, string>>? _joinKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// Querybuiled
        /// </summary>
        /// <param name="data">data</param>
        public QueryBuilder(IEnumerable<T> data)
        {
            this._data = data;
        }

        /// <summary>
        /// Filters method to similar where method.
        /// </summary>
        /// <param name="condition">condition</param>
        /// <returns>this</returns>
        public QueryBuilder<T> Filter(Expression<Func<T, bool>> condition)
        {
            this._filters.Add(condition);

            return this;
        }

        /// <summary>
        /// Sorts method similar to order by method.
        /// </summary>
        /// <param name="property">property</param>
        /// <returns>this</returns>
        public QueryBuilder<T> SortBy(Expression<Func<T, object>> property)
        {
            this._sortExpression = property;

            return this;
        }

        /// <summary>
        /// Joins two or more collections via keys.
        /// </summary>
        /// <param name="data">d</param>
        /// <param name="dataKey">s</param>
        /// <param name="joinKey">j</param>
        /// <returns>this</returns>
        public QueryBuilder<T> Join(
            IEnumerable<T> data,
            Expression<Func<T, string>> dataKey,
            Expression<Func<T, string>> joinKey)
        {
            this._joinData = data;
            this._dataKey = dataKey;
            this._joinKey = joinKey;

            return this;
        }

        /// <summary>
        /// Immediate Execution of the queries.
        /// </summary>
        /// <returns>List</returns>
        public List<T> Execute()
        {
            IEnumerable<T> query = this._data;

            foreach (var filter in this._filters)
            {
                query = query.Where(filter.Compile());
            }

            if (this._joinData.Any())
            {
                query = query.Join(
                    this._joinData,
                    this._dataKey.Compile(),
                    this._joinKey.Compile(),
                    (item, joinedItem) => item);
            }

            if (this._sortExpression != null)
            {
                query = query.OrderBy(this._sortExpression.Compile());
            }

            return query.ToList();
        }
    }
}

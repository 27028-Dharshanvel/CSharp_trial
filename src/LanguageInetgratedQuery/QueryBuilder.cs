using System.Linq.Expressions;
using LanguageInetgratedQuery.Models;

namespace LanguageInetgratedQuery
{
    /// <summary>
    /// Query Builder
    /// </summary>
    internal class QueryBuilder
    {
        private IEnumerable<Product> _products;

        private List<Expression<Func<Product, bool>>> _filters =
            new List<Expression<Func<Product, bool>>>();

        private Expression<Func<Product, object>> _sortExpression;

        private List<Product> _joinProducts =
            new List<Product>();

        private Expression<Func<Product, string>> _productKey;

        private Expression<Func<Product, string>> _joinKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder"/> class.
        /// QueryBuilder
        /// </summary>
        /// <param name="products">products</param>
        public QueryBuilder(List<Product> products)
        {
            _products = products;
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="condition">condition</param>
        /// <returns>QueryBuilder</returns>
        public QueryBuilder Filter(Expression<Func<Product, bool>> condition)
        {
            _filters.Add(condition);

            return this;
        }

        /// <summary>
        /// SortBy
        /// </summary>
        /// <param name="property">property</param>
        /// <returns>QueryBuilder</returns>
        public QueryBuilder SortBy(Expression<Func<Product, object>> property)
        {
            _sortExpression = property;

            return this;
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="products">products</param>
        /// <param name="productKey">product key</param>
        /// <param name="joinKey">join key</param>
        /// <returns>QueryBuilder</returns>
        public QueryBuilder Join(
            List<Product> products,
            Expression<Func<Product, string>> productKey,
            Expression<Func<Product, string>> joinKey)
        {
            _joinProducts = products;
            _productKey = productKey;
            _joinKey = joinKey;

            return this;
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <returns>result</returns>
        public List<Product> Execute()
        {
            IEnumerable<Product> query = _products;

            foreach (var filter in _filters)
            {
                query = query.Where(filter.Compile());
            }

            if (_joinProducts.Count > 0)
            {
                query = query.Join(
                    _joinProducts,
                    _productKey.Compile(),
                    _joinKey.Compile(),
                    (product, joinProduct) => product);
            }

            if (_sortExpression != null)
            {
                query = query.OrderBy(_sortExpression.Compile());
            }

            return query.ToList();
        }
    }
}
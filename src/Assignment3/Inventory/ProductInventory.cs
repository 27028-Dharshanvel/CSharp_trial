using Assignment3.Models;

namespace Assignment3.Inventory
{
    /// <summary>
    /// Inventory
    /// </summary>
    internal class ProductInventory
    {
        private List<Product>? _products = new List<Product>();

        /// <summary>
        /// Add Products to inventory
        /// </summary>
        /// <param name="product">products</param>
        /// <returns>product</returns>
        public bool Add(Product product)
        {
            if (product == null)
            {
                return false;
            }
            else
            {
                _products.Add(product);
                return true;
            }
        }

        /// <summary>
        /// GetsProducts
        /// </summary>
        /// <returns>products</returns>
        public List<Product> GetProduct()
        {
            return _products.Select(p => p.Clone()).ToList();
        }
    }
}

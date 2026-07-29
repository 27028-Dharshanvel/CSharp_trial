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
        /// Gets Products
        /// </summary>
        /// <returns>products</returns>
        public List<Product> GetProduct()
        {
            return _products.Select(p => p.Clone()).ToList();
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="productName">Product Name</param>
        /// <param name="product">Updated Product</param>
        /// <returns>Boolean</returns>
        public bool Edit(string productId, string productName, Product product)
        {
            Product? existingProduct = _products.FirstOrDefault(p =>
                p.ProductId == productId &&
                p.Name != null &&
                p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

            return true;
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>Boolean</returns>
        public bool Delete(string value)
        {
            Product? product = _products.FirstOrDefault(p =>
                p.ProductId == value ||
                (p.Name != null &&
                p.Name.Equals(value, StringComparison.OrdinalIgnoreCase)));

            if (product == null)
            {
                return false;
            }

            _products.Remove(product);

            return true;
        }

        /// <summary>
        /// Search Product
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>Products</returns>
        public List<Product> Search(string value)
        {
            return _products
                .Where(p =>
                    p.ProductId == value ||
                    (p.Name != null &&
                    p.Name.Contains(value, StringComparison.OrdinalIgnoreCase)))
                .Select(p => p.Clone())
                .ToList();
        }

        /// <summary>
        /// Sort Products by Name
        /// </summary>
        /// <returns>Products</returns>
        public List<Product> SortByName()
        {
            return _products
                .OrderBy(p => p.Name)
                .Select(p => p.Clone())
                .ToList();
        }

        /// <summary>
        /// Sort Products by Price
        /// </summary>
        /// <returns>Products</returns>
        public List<Product> SortByPrice()
        {
            return _products
                .OrderBy(p => p.Price)
                .Select(p => p.Clone())
                .ToList();
        }
    }
}
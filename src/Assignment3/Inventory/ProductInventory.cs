using Assignment3.Models;

namespace Assignment3.Inventory
{
    /// <summary>
    /// Inventory class to manage products.
    /// </summary>
    internal class ProductInventory
    {
        private List<Product> _products = new List<Product>();

        /// <summary>
        /// Add Products to inventory
        /// </summary>
        /// <param name="product">Instance of Product.</param>
        /// <returns>True if product is added successfully, false otherwise.</returns>
        public bool Add(Product product)
        {
            if (product == null || this.ProductIdExists(product.ProductId))
            {
                return false;
            }
            else
            {
                this._products.Add(product);
                return true;
            }
        }

        /// <summary>
        /// Gets Products from inventory.
        /// </summary>
        /// <returns>List of Products.</returns>
        public List<Product> GetProducts()
        {
            return this._products.Select(p => p.Clone()).ToList();
        }

        /// <summary>
        /// Edit Product in inventory.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="product">Updated Product</param>
        /// <returns>True if product is edited successfully, false otherwise.</returns>
        public bool Edit(string productId, Product product)
        {
            Product? existingProduct = this._products.FirstOrDefault(p =>
                p.ProductId == productId );

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
        /// Delete Product from inventory.
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>True if product is deleted successfully, false otherwise.</returns>
        public bool Delete(string value)
        {
            Product? product = this._products.FirstOrDefault(p =>
                p.ProductId == value ||
                (p.Name != null &&
                p.Name.Equals(value, StringComparison.OrdinalIgnoreCase)));

            if (product == null)
            {
                return false;
            }

            this._products.Remove(product);

            return true;
        }

        /// <summary>
        /// Search Product from inventory.
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>List of Products.</returns>
        public List<Product> Search(string value)
        {
            return this._products
                .Where(p =>
                    p.ProductId == value ||
                    (p.Name != null &&
                    p.Name.Contains(value, StringComparison.OrdinalIgnoreCase)))
                .Select(p => p.Clone())
                .ToList();
        }

        /// <summary>
        /// Sort Products by Name.
        /// </summary>
        /// <returns>List of Products.</returns>
        public List<Product> SortByName()
        {
            return this._products
                .OrderBy(p => p.Name)
                .Select(p => p.Clone())
                .ToList();
        }

        /// <summary>
        /// Sort Products by Price.
        /// </summary>
        /// <returns>List of Products.</returns>
        public List<Product> SortByPrice()
        {
            return this._products
                .OrderBy(p => p.Price)
                .Select(p => p.Clone())
                .ToList();
        }

        /// <summary>
        /// Checks whether Product Id already exists.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>True if product id exists, false otherwise.</returns>
        public bool ProductIdExists(string productId)
        {
            return this._products.Any(p =>
                p.ProductId.Equals(productId, StringComparison.OrdinalIgnoreCase));
        }
    }
}
using Assignment3.Inventory;
using Assignment3.Models;

namespace Assignment3.Service
{
    /// <summary>
    /// Services
    /// </summary>
    internal class Services
    {
        private ProductInventory _inventory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Services"/> class.
        /// </summary>
        /// <param name="inventory">inventory</param>
        public Services(ProductInventory inventory)
        {
            this._inventory = inventory;
        }

        /// <summary>
        /// Adds product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="productName">Product Name</param>
        /// <param name="productPrice">Product Price</param>
        /// <param name="productQuantity">Product Quantity</param>
        /// <returns>Boolean</returns>
        public bool AddProduct(
            string productId,
            string productName,
            decimal productPrice,
            double productQuantity)
        {
            Product product = new Product();

            product.Id = Guid.NewGuid();
            product.ProductId = productId;
            product.Name = productName;
            product.Price = productPrice;
            product.Quantity = productQuantity;

            if (this._inventory.Add(product))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Views Products
        /// </summary>
        /// <returns>Product List</returns>
        public List<Product> ViewProducts()
        {
            return this._inventory.GetProducts();
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="newName">New Product Name</param>
        /// <param name="newPrice">New Product Price</param>
        /// <param name="newQuantity">New Product Quantity</param>
        /// <returns>Boolean</returns>
        public bool EditProduct(
            string productId,
            string newName,
            decimal newPrice,
            double newQuantity)
        {
            Product product = new Product();

            product.ProductId = productId;
            product.Name = newName;
            product.Price = newPrice;
            product.Quantity = newQuantity;

            return this._inventory.Edit(productId, product);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>Boolean</returns>
        public bool DeleteProduct(string value)
        {
            return this._inventory.Delete(value);
        }

        /// <summary>
        /// Search Product
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>Product List</returns>
        public List<Product> SearchProduct(string value)
        {
            return this._inventory.Search(value);
        }

        /// <summary>
        /// Sort Products by name.
        /// </summary>
        /// <returns>Product List</returns>
        public List<Product>? SortByName()
        {
                return this._inventory.SortByName();
        }

        /// <summary>
        /// Sort Products by name.
        /// </summary>
        /// <returns>Product List</returns>
        public List<Product>? SortByPrice()
        {
            return this._inventory.SortByPrice();
        }

        /// <summary>
        /// Checks the repository is empty.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmptyRepository()
        {
            List<Product> products = this.ViewProducts();
            if (products.Any())
            {
                return false;
            }

            return true;
        }
    }
}
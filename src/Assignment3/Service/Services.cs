using Assignment3.Inventory;
using Assignment3.Models;

namespace Assignment3.Service
{
    /// <summary>
    /// Services class to handle product operations.
    /// </summary>
    internal class Services
    {
        private ProductInventory _inventory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Services"/> class.
        /// </summary>
        /// <param name="inventory">Instance of ProductInventory.</param>
        public Services(ProductInventory inventory)
        {
            this._inventory = inventory;
        }

        /// <summary>
        /// Adds product to the inventory.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="productName">Product Name</param>
        /// <param name="productPrice">Product Price</param>
        /// <param name="productQuantity">Product Quantity</param>
        /// <returns>True if product is added successfully, false otherwise.</returns>
        public bool AddProduct(
            string productId,
            string productName,
            decimal productPrice,
            double productQuantity)
        {
            Product product = new Product();

            product.ProductId = productId;
            product.Name = productName;
            product.Price = productPrice;
            product.Quantity = productQuantity;

            return this._inventory.Add(product);
        }

        /// <summary>
        /// Views Products from the inventory.
        /// </summary>
        /// <returns>List of Products.</returns>
        public List<Product> ViewProducts()
        {
            return this._inventory.GetProducts();
        }

        /// <summary>
        /// Edit Product in the inventory.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="newName">New Product Name</param>
        /// <param name="newPrice">New Product Price</param>
        /// <param name="newQuantity">New Product Quantity</param>
        /// <returns>True if product is edited successfully, false otherwise.</returns>
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
        /// Delete Product from the inventory.
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>True if product is deleted successfully, false otherwise.</returns>
        public bool DeleteProduct(string value)
        {
            return this._inventory.Delete(value);
        }

        /// <summary>
        /// Search Product from the inventory.
        /// </summary>
        /// <param name="value">Product Id or Name</param>
        /// <returns>List of Products.</returns>
        public List<Product> SearchProduct(string value)
        {
            return this._inventory.Search(value);
        }

        /// <summary>
        /// Sort Products by name.
        /// </summary>
        /// <returns>List of Products.</returns>
        public List<Product>? SortByName()
        {
                return this._inventory.SortByName();
        }

        /// <summary>
        /// Sort Products by name.
        /// </summary>
        /// <returns>List of Products.</returns>
        public List<Product>? SortByPrice()
        {
            return this._inventory.SortByPrice();
        }

        /// <summary>
        /// Checks whether the repository is empty.
        /// </summary>
        /// <returns>True if the repository is empty, false otherwise.</returns>
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
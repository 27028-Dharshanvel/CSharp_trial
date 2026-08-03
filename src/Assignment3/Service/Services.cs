using Assignment3.Inventory;
using Assignment3.Models;

namespace Assignment3.Service
{
    /// <summary>
    /// Services
    /// </summary>
    internal class Services
    {
        private ProductInventory _inventory = new ProductInventory();

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
            return this._inventory.GetProduct();
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="oldName">Existing Product Name</param>
        /// <param name="newName">New Product Name</param>
        /// <param name="newPrice">New Product Price</param>
        /// <param name="newQuantity">New Product Quantity</param>
        /// <returns>Boolean</returns>
        public bool EditProduct(
            string productId,
            string oldName,
            string newName,
            decimal newPrice,
            double newQuantity)
        {
            Product product = new Product();

            product.ProductId = productId;
            product.Name = newName;
            product.Price = newPrice;
            product.Quantity = newQuantity;

            return this._inventory.Edit(productId, oldName, product);
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
        /// Sort Products
        /// </summary>
        /// <param name="choice">Sort Choice</param>
        /// <returns>Product List</returns>
        public List<Product> SortProducts(int choice)
        {
            if (choice == 1)
            {
                return this._inventory.SortByName();
            }
            else
            {
                return this._inventory.SortByPrice();
            }
        }
    }
}
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
        /// Adds product name
        /// </summary>
        /// <param name="productName">productName</param>
        /// <param name="productPrice">productPrice</param>
        /// <param name="productQuantity">productQuantity</param>
        /// <returns>boolean</returns>
        public bool AddProduct(string productName, double productPrice, double productQuantity)
        {
            Product product = new Product();
            product.Name = productName;
            product.Price = productPrice;
            product.Quantity = productQuantity;
            product.Id = Guid.NewGuid();
            if (this._inventory.Add(product))
            {
                product.Name = "Random Name";
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ViewsProducts
        /// </summary>
        /// <returns>Product List</returns>
        public List<Product> ViewProducts()
        {
           return _inventory.GetProduct();
        }
    }
}

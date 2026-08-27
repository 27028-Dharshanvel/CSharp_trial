using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInetgratedQuery.Models;

namespace LanguageInetgratedQuery.Repository
{
    /// <summary>
    /// Repository
    /// </summary>
    internal class Repository
    {
        private List<Product> _products = new List<Product>
        {
            new Product
            {
                ProductId = "001",
                ProductName = "IronBox",
                ProductCategory = "Electronics",
                ProductPrice = 1500,
            },
            new Product
            {
                ProductId = "002",
                ProductName = "Charger",
                ProductCategory = "Electronics",
                ProductPrice = 2000,
            },
            new Product
            {
                ProductId = "003",
                ProductName = "Soap",
                ProductCategory = "Cleaning",
                ProductPrice = 80,
            },
            new Product
            {
                ProductId = "004",
                ProductName = "WaterBottle",
                ProductCategory = "Utensils",
                ProductPrice = 400,
            },
            new Product
            {
                ProductId = "005",
                ProductName = "Notebook",
                ProductCategory = "Education",
                ProductPrice = 180,
            },
            new Product
            {
                ProductId = "006",
                ProductName = "Heater",
                ProductCategory = "Electronics",
                ProductPrice = 3500,
            },
            new Product
            {
                ProductId = "007",
                ProductName = "Extension cord",
                ProductCategory = "Electronics",
                ProductPrice = 400,
            },
        };

        private List<Supplier> _suppliers = new List<Supplier>();

        /// <summary>
        /// Get
        /// </summary>
        /// <returns>list</returns>
        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}

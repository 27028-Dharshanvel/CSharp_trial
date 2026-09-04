using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInetgratedQuery.Models;

namespace LanguageInetgratedQuery.Repositories
{
    /// <summary>
    /// ProductRepository
    /// </summary>
    internal class ProductRepository
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
            new Product
            {
                ProductId = "008",
                ProductName = "C# Programming Book",
                ProductCategory = "Books",
                ProductPrice = 800,
            },
            new Product
            {
                ProductId = "009",
                ProductName = "LINQ Programming Book",
                ProductCategory = "Books",
                ProductPrice = 600,
            },
            new Product
            {
                ProductId = "010",
                ProductName = "Advanced C# Book",
                ProductCategory = "Books",
                ProductPrice = 1200,
            },
        };

        private string[] _categories = { "Books", "Electronics", "Clothing", "Home", "Beauty" };
        private Random _rand = new Random();
        private List<Product> _mockProducts = new List<Product>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        public ProductRepository()
        {
            for (int i = 0; i < this._mockProducts.Count; i++)
            {
                this._mockProducts[i] = new Product
                {
                    ProductName = $"Product {i}",
                    ProductPrice = Math.Round((this._rand.NextDouble() * (500 - 5)) + 5, 2),
                    ProductCategory = this._categories[this._rand.Next(this._categories.Length)],
                };
            }
        }

        /// <summary>
        /// Gets products.
        /// </summary>
        /// <returns>list</returns>
        public List<Product> GetProducts()
        {
            return this._products;
        }

        /// <summary>
        /// Gets products.
        /// </summary>
        /// <returns>list</returns>
        public List<Product> GetMockProducts()
        {
            return this._mockProducts;
        }
    }
}
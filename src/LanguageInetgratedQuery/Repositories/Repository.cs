using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInetgratedQuery.Models;

namespace LanguageInetgratedQuery.Repositories
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

        private List<Supplier> _suppliers = new List<Supplier>
        {
            new Supplier
            {
                SupplierId = "S001",
                SupplierName = "ABC Electronics",
                ProductId = "001",
            },
            new Supplier
            {
                SupplierId = "S002",
                SupplierName = "XYZ Electronics",
                ProductId = "002",
            },
            new Supplier
            {
                SupplierId = "S003",
                SupplierName = "Home Appliances Supplier",
                ProductId = "006",
            },
            new Supplier
            {
                SupplierId = "S004",
                SupplierName = "Book World",
                ProductId = "008",
            },
            new Supplier
            {
                SupplierId = "S005",
                SupplierName = "Knowledge Suppliers",
                ProductId = "009",
            },
            new Supplier
            {
                SupplierId = "S006",
                SupplierName = "Book House",
                ProductId = "010",
            },
        };

        private int[] _numbers =
        {
            2,
            5,
            8,
            3,
            7,
            5,
            1,
            9
        };

        /// <summary>
        /// Get
        /// </summary>
        /// <returns>list</returns>
        public List<Product> GetProducts()
        {
            return this._products;
        }

        /// <summary>
        /// Get Suppliers
        /// </summary>
        /// <returns>list</returns>
        public List<Supplier> GetSuppliers()
        {
            return this._suppliers;
        }

        /// <summary>
        /// Get Numbers
        /// </summary>
        /// <returns>array</returns>
        public int[] GetNumbers()
        {
            return this._numbers;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInetgratedQuery.Models;

namespace LanguageInetgratedQuery.Repositories
{
    /// <summary>
    /// SupplierRepository
    /// </summary>
    internal class SupplierRepository
    {
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

        /// <summary>
        /// Get Suppliers
        /// </summary>
        /// <returns>list</returns>
        public List<Supplier> GetSuppliers()
        {
            return this._suppliers;
        }
    }
}

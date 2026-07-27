using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    /// <summary>
    /// Products
    /// </summary>
    internal class Products
    {
        /// <summary>
        /// Gets or sets unique Id for product
        /// </summary>
        /// <value>
        /// Guid.
        /// </value>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        /// <value>
        /// Price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets quantuty
        /// </summary>
        /// <value>
        /// quantity
        /// </value>
        public double? Quantity { get; set; }
    }
}

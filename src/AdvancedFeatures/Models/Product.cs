using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Models
{
    /// <summary>
    /// Product class
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets category
        /// </summary>
        /// <value>
        /// Category
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        /// <value>
        /// Price
        /// </value>
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    /// <summary>
    /// Transaction
    /// </summary>
    internal class Transaction
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        /// <value>Id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        /// <value>Amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Note
        /// </summary>
        /// <value>Id.</value>
        public string? Description { get; set; }
    }
}

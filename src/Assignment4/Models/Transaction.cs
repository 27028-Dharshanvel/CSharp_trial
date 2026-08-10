using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    /// <summary>
    /// Represents Transaction Model.
    /// </summary>
    internal class Transaction
    {
        /// <summary>
        /// Gets or sets transaction id.
        /// </summary>
        /// <value>Id.</value>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        /// <value>Amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Date of the transaction.
        /// </summary>
        /// <value>Date.</value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets category of transaction.
        /// </summary>
        /// <value>Category.</value>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        /// <value>
        /// User id.
        /// </value>
        public Guid UserId { get; set; }
    }
}

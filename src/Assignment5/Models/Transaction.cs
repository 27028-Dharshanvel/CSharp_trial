using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    /// <summary>
    /// Represents Transaction Model.
    /// </summary>
    internal class Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <param name="date">The date of the transaction.</param>
        /// <param name="category">The category of the transaction.</param>
        /// <param name="userId">The ID of the user associated with the transaction.</param>
        public Transaction(decimal amount, DateOnly date, string? category, Guid userId)
        {
            this.TransactionId = Guid.NewGuid();
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
            this.UserId = userId;
        }

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

        /// <summary>
        /// Clone method.
        /// </summary>
        /// <returns>Cloned object of Transaction.</returns>
        public Transaction Clone()
        {
            return new Transaction(this.Amount, this.Date, this.Category, this.UserId)
            {
                TransactionId = this.TransactionId,
            };
        }
    }
}

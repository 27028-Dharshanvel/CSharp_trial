namespace Assignment4.Models
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
        public Transaction(decimal amount, DateOnly date, string category, Guid userId)
        {
            this.TransactionId = Guid.NewGuid();
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
            this.UserId = userId;
        }

        /// <summary>
        /// Gets transaction id.
        /// </summary>
        /// <value>Id of transaction</value>
        public Guid TransactionId { get; init; }

        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        /// <value>Transaction amount</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Date of the transaction.
        /// </summary>
        /// <value>Date of transaction.</value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets category of transaction.
        /// </summary>
        /// <value>Category of transaction.</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        /// <value>
        /// User id of transaction.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Creates a clone of the current transaction instance.
        /// </summary>
        /// <returns>Transaction instance</returns>
        public Transaction Clone()
        {
            return new Transaction(this.Amount, this.Date, this.Category, this.UserId)
            {
                TransactionId = this.TransactionId,
            };
        }
    }
}

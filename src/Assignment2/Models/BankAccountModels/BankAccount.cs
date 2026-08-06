namespace Assignment2.BankAccountModels
{
    /// <summary>
    /// Bank Account
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Gets or sets AccountNumber.
        /// </summary>
        /// <value>
        /// AccountNumber ins string.
        /// </value>
        public string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets AccountHolder.
        /// </summary>
        /// <value>
        /// AccountHolder name as string.
        /// </value>
        public string AccountHolder { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets AccountBalance.
        /// </summary>
        /// <value>
        /// Account Balance
        /// </value>
        public decimal AccountBalance { get; set; } = 0;

        /// <summary>
        /// Default Withdraw method to withdraw amount.
        /// </summary>
        /// <param name="amount"> amount </param>
        /// <returns>True if withdrawal succeeded; otherwise, false.</returns>
        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (amount <= this.AccountBalance)
            {
                this.AccountBalance = this.AccountBalance - amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Default Deposit method to deposit amount.
        /// </summary>
        /// <param name="amount"> amount </param>
        /// <returns>True if deposit succeeded; otherwise, false.</returns>
        public virtual bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            this.AccountBalance = this.AccountBalance + amount;
            return true;
        }
    }
}

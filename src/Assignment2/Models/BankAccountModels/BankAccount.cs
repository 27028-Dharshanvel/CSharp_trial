using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// AccountNumber.
        /// </value>
        public string AccountNumber { get; set; } = string.Empty;

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
        public virtual void Withdraw(decimal amount)
        {
            this.AccountBalance = this.AccountBalance - amount;
        }

        /// <summary>
        /// Default Deposit method to deposit amount.
        /// </summary>
        /// <param name="amount"> amount </param>
        public virtual void Deposit(decimal amount)
        {
            this.AccountBalance = this.AccountBalance + amount;
        }
    }
}

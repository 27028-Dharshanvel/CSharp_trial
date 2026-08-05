using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.BankAccountModels
{
    /// <summary>
    /// Savings Account
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Gets or sets minimum Balance.
        /// </summary>
        /// <value>
        /// Minimum Balance.
        /// </value>
        public int MinimumBalance { get; set; } = 1000;

        /// <summary>
        /// Withdraw method to withdraw amount from accountbalance.
        /// </summary>
        /// <param name="amount">amount</param>
        /// <returns>True if withdrawal succeeded; otherwise, false.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if ((this.AccountBalance - amount) >= this.MinimumBalance)
            {
                this.AccountBalance = this.AccountBalance - amount;
                return true;
            }

            return false;
        }
    }
}

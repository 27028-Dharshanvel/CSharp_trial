using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.BankAccountModels
{
    /// <summary>
    /// Checking Account
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Withdraw method to withdraw amount from accountbalance.
        /// </summary>
        /// <param name="amount"> amount </param>
        /// <returns>True if withdrawal succeeded; otherwise, false.</returns>
        public override bool Withdraw(decimal amount)
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
    }
}

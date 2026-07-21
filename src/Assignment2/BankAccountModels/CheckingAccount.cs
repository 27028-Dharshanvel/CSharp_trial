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
        /// Withdraw
        /// </summary>
        /// <param name="amount"> amount </param>
        public override void Withdraw(int amount)
        {
            if (amount < this.AccountBalance)
            {
                this.AccountBalance = this.AccountBalance - amount;
            }
        }
    }
}

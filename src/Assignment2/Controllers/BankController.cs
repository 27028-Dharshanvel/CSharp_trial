using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.BankAccountModels;
using Assignment2.Helpers;

namespace Assignment2.BankAccountServices
{
    /// <summary>
    /// BankController
    /// </summary>
    internal class BankController
    {
        /// <summary>
        /// Deposit amount
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        public void Deposit(BankAccount account, int amount)
        {
            account.Deposit(amount);
        }

        /// <summary>
        /// Withdraw amount
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        public void Withdraw(BankAccount account, int amount)
        {
            account.Withdraw(amount);
        }
    }
}

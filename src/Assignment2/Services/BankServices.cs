using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.BankAccountModels;
using Assignment2.Helpers;
using Assignment2.Repository;

namespace Assignment2.BankAccountServices
{
    /// <summary>
    /// Bank Services
    /// </summary>
    internal class BankServices
    {

        private BankRepository _bankRepository = new BankRepository();

        /// <summary>
        /// Deposits amount to bank account.
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        public void Deposit(BankAccount account, decimal amount)
        {
            account.Deposit(amount);
            _bankRepository.Update(account);
        }

        /// <summary>
        /// Withdraws amount from bank account.
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        public void Withdraw(BankAccount account, decimal amount)
        {
            account.Withdraw(amount);
            _bankRepository.Update(account);
        }
    }
}

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
        /// Creates a new bank account.
        /// </summary>
        /// <param name="account">Bank account.</param>
        /// <returns>The created bank account with assigned account number.</returns>
        public BankAccount CreateAccount(BankAccount account)
        {
            long nextAccNum = this._bankRepository.GetNextAccountNumber();
            account.AccountNumber = nextAccNum.ToString();
            this._bankRepository.Create(account);
            return account;
        }

        /// <summary>
        /// Gets account by account number.
        /// </summary>
        /// <param name="accountNumber">Account number.</param>
        /// <returns>Bank account if found, otherwise null.</returns>
        public BankAccount? GetAccount(string accountNumber)
        {
            return this._bankRepository.GetAccountByNumber(accountNumber);
        }

        /// <summary>
        /// Deposits amount to bank account.
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        /// <returns>True if deposit succeeded, false otherwise.</returns>
        public bool Deposit(BankAccount account, decimal amount)
        {
            bool success = account.Deposit(amount);
            if (success)
            {
                this._bankRepository.Update(account);
            }

            return success;
        }

        /// <summary>
        /// Withdraws amount from bank account.
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        /// <returns>True if withdrawal succeeded, false otherwise.</returns>
        public bool Withdraw(BankAccount account, decimal amount)
        {
            bool success = account.Withdraw(amount);
            if (success)
            {
                this._bankRepository.Update(account);
            }

            return success;
        }
    }
}

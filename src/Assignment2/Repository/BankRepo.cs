using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assignment2.BankAccountModels;
using Assignment2.Models;

namespace Assignment2.Repository
{
    /// <summary>
    /// Bank Repository
    /// </summary>
    internal class BankRepo
    {
        private readonly List<BankAccount>?_bankAccounts;

        /// <summary>
        /// To get Account number
        /// </summary>
        /// <param name="accountNumber">accountNumber</param>
        /// <returns>AccountNumber as string</returns>
        public BankAccount? GetByAccountNumber(string accountNumber)
        {
            return _bankAccounts.FirstOrDefault(a =>  a.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Adds account to repository
        /// </summary>
        /// <param name="bankAccount">bankAccount</param>
        public void Add(BankAccount bankAccount)
        {
            _bankAccounts.Add(bankAccount);
        }

        /// <summary>
        /// Removes account from repository
        /// </summary>
        /// <param name="bankAccount">bankAccount</param>
        public void Remove(BankAccount bankAccount)
        {
            _bankAccounts.Remove(bankAccount);
        }
    }
}

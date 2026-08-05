using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.BankAccountModels;

namespace Assignment2.Repository
{
    /// <summary>
    /// Bank Repository
    /// </summary>
    internal class BankRepository
    {
        private List<BankAccount> _bankAccounts = new List<BankAccount>();

        /// <summary>
        /// Creates a new account in bank repository.
        /// </summary>
        /// <param name="bankAccount">Bank account.</param>
        public void Create(BankAccount bankAccount)
        {
            this._bankAccounts.Add(bankAccount);
        }

        /// <summary>
        /// Reads account details in bank repository.
        /// </summary>
        /// <param name="bankAccount">Bank account.</param>
        public void Read(BankAccount bankAccount)
        {
        }

        /// <summary>
        /// Updates bank account in bank repository.
        /// </summary>
        /// <param name="bankAccount">Bank account.</param>
        public void Update(BankAccount bankAccount)
        {
            this._bankAccounts.Add(bankAccount);
        }

        /// <summary>
        /// Delets account in bank repository.
        /// </summary>
        /// <param name="bankAccount">Bank account.</param>
        public void Delete(BankAccount bankAccount)
        {
            this._bankAccounts.Remove(bankAccount);
        }
    }
}

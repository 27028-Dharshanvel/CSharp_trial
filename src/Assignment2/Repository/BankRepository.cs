using System.Security.Cryptography;
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
        /// Gets next available account number.
        /// </summary>
        /// <returns>Next unique account number.</returns>
        public long GetNextAccountNumber()
        {
            return RandomNumberGenerator.GetInt32(10000000, 99999999);
        }

        /// <summary>
        /// Checks if an account exists by account number.
        /// </summary>
        /// <param name="accountNumber">Account number.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool Exists(string accountNumber)
        {
            return this._bankAccounts.Any(a => a.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Reads / Gets account by account number.
        /// </summary>
        /// <param name="accountNumber">Account number.</param>
        /// <returns>Bank account if found, otherwise null.</returns>
        public BankAccount? GetAccountByNumber(string accountNumber)
        {
            return this._bankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Creates a new account in bank repository.
        /// </summary>
        /// <param name="bankAccount">Bank account.</param>
        public void Create(BankAccount bankAccount)
        {
            this._bankAccounts.Add(bankAccount);
        }

        /// <summary>
        /// Updates bank account in bank repository.
        /// </summary>
        /// <param name="bankAccount">Bank account.</param>
        public void Update(BankAccount bankAccount)
        {
            BankAccount? existing = this.GetAccountByNumber(bankAccount.AccountNumber);
            if (existing == null)
            {
                this._bankAccounts.Add(bankAccount);
            }
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

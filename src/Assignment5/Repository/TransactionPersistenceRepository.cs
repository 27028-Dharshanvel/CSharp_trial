using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment5.Models;

namespace Assignment5.Repository
{
    /// <summary>
    /// Transaction Repository.
    /// </summary>
    internal class TransactionPersistenceRepository : ITransactionRepository
    {
        private readonly string _filePath = "transactions.json";

        /// <summary>
        /// Add transactions.
        /// </summary>
        /// <param name="transaction">transaction</param>
        public void AddTransaction(Transaction transaction)
        {
            var transactions = LoadTransactions();
            transactions.Add(transaction);
            SaveTransactions(transactions);
        }

        /// <summary>
        /// Deletes transaction.
        /// </summary>
        /// <param name="transaction">transaction</param>
        /// <exception cref="NotImplementedException">Notimplemented exception.</exception>
        public void DeleteTransaction(Transaction transaction)
        {

            var transactions = LoadTransactions();

            transactions.RemoveAll(u => u.TransactionId == transaction.TransactionId);

            this.SaveTransactions(transactions);
        }

        /// <summary>
        /// Loads transactions.
        /// </summary>
        /// <returns>list of transactions.</returns>
        /// <exception cref="NotImplementedException">notimplemented exception.</exception>
        public List<Transaction> LoadTransactions()
        {
            if(!File.Exists(_filePath))
            {
                return new List<Transaction>();
            }

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Transaction>();
            }

            return JsonSerializer.Deserialize<List<Transaction>>(json)
                   ?? new List<Transaction>();
        }

        /// <summary>
        /// Saves transactions.
        /// </summary>
        /// <param name="transactions">transaction</param>
        /// <exception cref="NotImplementedException">not implemented exception.</exception>
        public void SaveTransactions(List<Transaction> transactions)
        {
            string json = JsonSerializer.Serialize(
                transactions,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Update transacions.
        /// </summary>
        /// <param name="oldTransaction">old transaction.</param>
        /// <param name="updatedTransaction">updated transaction.</param>
        /// <exception cref="NotImplementedException">not implemented exception.</exception>
        public void UpdateTransaction(Transaction oldTransaction, Transaction updatedTransaction)
        {
            var transactions = LoadTransactions();

            int index = transactions.FindIndex(u => u.TransactionId == oldTransaction.TransactionId);

            if (index == -1)
            {
                throw new InvalidOperationException("User not found.");
            }

            transactions[index] = updatedTransaction;

            SaveTransactions(transactions);
        }
    }
}

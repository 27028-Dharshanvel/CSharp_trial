using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Interface for Transaction Repository.
    /// </summary>
    internal interface ITransactionRepository
    {
        /// <summary>
        /// Save transactions.
        /// </summary>
        /// <param name="transactions">transactions</param>
        void SaveTransactions(List<Transaction> transactions);

        /// <summary>
        /// Loads Transactions.
        /// </summary>
        /// <returns>List of transaction.</returns>
        List<Transaction> LoadTransactions();

        /// <summary>
        /// Adds Transaction.
        /// </summary>
        /// <param name="transaction">transaction</param>
        void AddTransaction(Transaction transaction);

        /// <summary>
        /// Deletes Transactions.
        /// </summary>
        /// <param name="transaction">transactions</param>
        void DeleteTransaction(Transaction transaction);

        /// <summary>
        /// Updates Transactions.
        /// </summary>
        /// <param name="oldTransaction">oldTransaction</param>
        /// <param name="updatedTransaction">updatedTransaction</param>
        void UpdateTransaction(Transaction oldTransaction, Transaction updatedTransaction);
    }
}

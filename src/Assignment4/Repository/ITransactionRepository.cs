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
        /// <param name="transactions">List of transactions.</param>
        void SaveTransactions(List<Transaction> transactions);

        /// <summary>
        /// Loads Transactions.
        /// </summary>
        /// <returns>List of transactions.</returns>
        List<Transaction> LoadTransactions();

        /// <summary>
        /// Adds Transaction.
        /// </summary>
        /// <param name="transaction">Instance of transaction</param>
        void AddTransaction(Transaction transaction);

        /// <summary>
        /// Deletes Transactions.
        /// </summary>
        /// <param name="transaction">Instance of transaction.</param>
        void DeleteTransaction(Transaction transaction);

        /// <summary>
        /// Updates Transactions.
        /// </summary>
        /// <param name="oldTransaction">oldTransaction instance.</param>
        /// <param name="updatedTransaction">updatedTransaction instance.</param>
        void UpdateTransaction(Transaction oldTransaction, Transaction updatedTransaction);
    }
}

using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Interface for Transaction Repository.
    /// </summary>
    internal interface ITransactionRepository
    {
        /// <summary>
        /// Save Contacts.
        /// </summary>
        /// <param name="transactions">contacts</param>
        void SaveTransactions(List<Transaction> transactions);

        /// <summary>
        /// Loads Transactions.
        /// </summary>
        /// <returns>List</returns>
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
        /// <param name="oldTransaction">oldtransaction</param>
        /// <param name="updatedTransaction">updatedTransaction</param>
        void UpdateTransaction(Transaction oldTransaction, Transaction updatedTransaction);
    }
}

using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Transaction List Repository.
    /// </summary>
    internal class TransactionListRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionListRepository"/> class.
        /// </summary>
        public TransactionListRepository()
        {
            this._transactions = new List<Transaction>();
        }

        /// <summary>
        /// Save transactions.
        /// </summary>
        /// <param name="transactions">List of transactions.</param>
        public void SaveTransactions(List<Transaction> transactions)
        {
            this._transactions = transactions;
        }

        /// <summary>
        /// Loads Transactions.
        /// </summary>
        /// <returns>List of transactions.</returns>
        public List<Transaction> LoadTransactions()
        {
            return this._transactions.Select(p => p.Clone()).ToList();
        }

        /// <summary>
        /// Adds Transactions.
        /// </summary>
        /// <param name="transaction">Instance of transaction.</param>
        public void AddTransaction(Transaction transaction)
        {
            this._transactions.Add(transaction);
        }

        /// <summary>
        /// Deletes Transactions.
        /// </summary>
        /// <param name="transaction">Instance of transaction.</param>
        public void DeleteTransaction(Transaction transaction)
        {
            this._transactions.Remove(transaction);
        }

        /// <summary>
        /// Update Transactions.
        /// </summary>
        /// <param name="oldTransaction">oldtransaction instance.</param>
        /// <param name="updatedTransaction">updatedTransaction instance.</param>
        public void UpdateTransaction(Transaction oldTransaction, Transaction updatedTransaction)
        {
            oldTransaction.Amount = updatedTransaction.Amount;
            oldTransaction.Date = updatedTransaction.Date;
            oldTransaction.Category = updatedTransaction.Category;
        }
    }
}

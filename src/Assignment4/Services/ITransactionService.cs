using Assignment4.Models;

namespace Assignment4.Services
{
    /// <summary>
    /// Interface for transaction services
    /// </summary>
    internal interface ITransactionService
    {
        /// <summary>
        /// Adds Transaction to the repository.
        /// </summary>
        /// <param name="userId">UserId of user.</param>
        /// <param name="amount">Amount to be added.</param>
        /// <param name="category">Category of the transaction.</param>
        /// <param name="date">Date of transaction.</param>
        /// <returns>True if transaction is added, False if error.</returns>
        public bool AddTransaction(Guid userId, decimal amount, string category, DateOnly date);

        /// <summary>
        /// Gets all transactions of a specific user
        /// </summary>
        /// <param name="userId">current user id.</param>
        /// <returns>List of transactions.</returns>
        public List<Transaction> GetAllTransactionsByUser(Guid userId);

        /// <summary>
        /// Gets transaction by Id.
        /// </summary>
        /// <param name="transactionId">Id of Transaction.</param>
        /// <returns>Transaction if found; otherwise null.</returns>
        public Transaction? GetTransactionById(Guid transactionId);

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id to update.</param>
        /// <param name="amount">Updated amount.</param>
        /// <param name="category">Updated category.</param>
        /// <param name="date">Updated date.</param>
        /// <returns>True if updated successfully; otherwise false.</returns>
        public bool UpdateTransaction(Guid transactionId, decimal amount, string category, DateOnly date);

        /// <summary>
        /// Deletes a transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id to delete.</param>
        /// <returns>True if deleted successfully; otherwise false.</returns>
        public bool DeleteTransaction(Guid transactionId);

        /// <summary>
        /// Checks whether the transaction repository is emtpy.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>True if empty, false otherwise.</returns>
        public bool IsEmptyRepository(Guid userId);

        /// <summary>
        /// Calculates total income.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <returns>Total income amount.</returns>
        public decimal GetTotalIncome(Guid userId);

        /// <summary>
        /// Calculates total expense.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <returns>Total expense amount.</returns>
        public decimal GetTotalExpense(Guid userId);

        /// <summary>
        /// Calculates net balance.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <returns>Net balance amount.</returns>
        public decimal GetNetBalance(Guid userId);
    }
}

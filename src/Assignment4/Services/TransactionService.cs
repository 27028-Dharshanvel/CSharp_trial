using Assignment4.Models;
using Assignment4.Repository;

namespace Assignment4.Services
{
    /// <summary>
    /// Service Class for managing transactions.
    /// </summary>
    internal class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="transactionRepository">Instance of transaction repository.</param>
        public TransactionService(ITransactionRepository transactionRepository)
        {
            this._transactionRepository = transactionRepository;
        }

        /// <summary>
        /// Adds Transaction to the repository.
        /// </summary>
        /// <param name="userId">UserId of user.</param>
        /// <param name="amount">Amount to be added.</param>
        /// <param name="category">Category of the transaction.</param>
        /// <param name="date">Date of transaction.</param>
        /// <returns>True if transaction is added, False if error.</returns>
        public bool AddTransaction(Guid userId, decimal amount, string category, DateOnly date)
        {
            Transaction transaction = new Transaction(amount, date, category, userId);

            this._transactionRepository.AddTransaction(transaction);
            return true;
        }

        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns>List of transactions.</returns>
        public List<Transaction> GetAllTransactions()
        {
            return this._transactionRepository.LoadTransactions();
        }

        /// <summary>
        /// Gets transaction by Id.
        /// </summary>
        /// <param name="transactionId">Id of Transaction.</param>
        /// <returns>Transaction if found; otherwise null.</returns>
        public Transaction? GetTransactionById(Guid transactionId)
        {
            List<Transaction> transactions = this._transactionRepository.LoadTransactions();

            return transactions.FirstOrDefault(transaction => transaction.TransactionId == transactionId);
        }

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id to update.</param>
        /// <param name="amount">Updated amount.</param>
        /// <param name="category">Updated category.</param>
        /// <param name="date">Updated date.</param>
        /// <returns>True if updated successfully; otherwise false.</returns>
        public bool UpdateTransaction(Guid transactionId, decimal amount, string category, DateOnly date)
        {
            Transaction? oldTransaction = this.GetTransactionById(transactionId);
            if (oldTransaction == null)
            {
                return false;
            }

            Transaction updatedTransaction = new Transaction(amount, date, category, oldTransaction.UserId);

            this._transactionRepository.UpdateTransaction(oldTransaction, updatedTransaction);
            return true;
        }

        /// <summary>
        /// Deletes a transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id to delete.</param>
        /// <returns>True if deleted successfully; otherwise false.</returns>
        public bool DeleteTransaction(Guid transactionId)
        {
            Transaction? transaction = this.GetTransactionById(transactionId);
            if (transaction == null)
            {
                return false;
            }

            this._transactionRepository.DeleteTransaction(transaction);
            return true;
        }

        /// <summary>
        /// Calculates total income.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <returns>Total income amount.</returns>
        public decimal GetTotalIncome(Guid userId)
        {
            decimal totalIncome = 0;
            List<Transaction> transactions = this._transactionRepository.LoadTransactions();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.UserId == userId)
                {
                    if (transaction.Amount > 0)
                    {
                        totalIncome += transaction.Amount;
                    }
                }
            }

            return totalIncome;
        }

        /// <summary>
        /// Calculates total expense.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <returns>Total expense amount.</returns>
        public decimal GetTotalExpense(Guid userId)
        {
            decimal totalExpense = 0;
            List<Transaction> transactions = this._transactionRepository.LoadTransactions();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.UserId == userId)
                {
                    if (transaction.Amount < 0)
                    {
                        totalExpense += Math.Abs(transaction.Amount);
                    }
                }
            }

            return totalExpense;
        }

        /// <summary>
        /// Calculates net balance.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <returns>Net balance amount.</returns>
        public decimal GetNetBalance(Guid userId)
        {
            return this.GetTotalIncome(userId) - this.GetTotalExpense(userId);
        }
    }
}

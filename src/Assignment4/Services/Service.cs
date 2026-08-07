using System;
using System.Collections.Generic;
using Assignment4.Models;
using Assignment4.Repository;

namespace Assignment4.Services
{
    /// <summary>
    /// Service Class for managing transactions.
    /// </summary>
    internal class Service
    {
        private ITransactionRepository _inMemoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="repository">repository.</param>
        public Service(ITransactionRepository repository)
        {
            this._inMemoryRepository = repository;
        }

        /// <summary>
        /// Adds Transaction to the repository.
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="category">category</param>
        /// <param name="date">date</param>
        /// <returns>True if transaction is added, False if error.</returns>
        public bool AddTransaction(decimal amount, string category, DateOnly date)
        {
            Transaction transaction = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                Amount = amount,
                Category = category,
                Date = date,
            };

            this._inMemoryRepository.AddTransaction(transaction);
            return true;
        }

        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns>List of transactions.</returns>
        public List<Transaction> GetAllTransactions()
        {
            return this._inMemoryRepository.LoadTransactions();
        }

        /// <summary>
        /// Gets transaction by Id.
        /// </summary>
        /// <param name="transactionId">Transaction Id.</param>
        /// <returns>Transaction if found; otherwise null.</returns>
        public Transaction? GetTransactionById(Guid transactionId)
        {
            List<Transaction> transactions = this._inMemoryRepository.LoadTransactions();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.TransactionId == transactionId)
                {
                    return transaction;
                }
            }

            return null;
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

            Transaction updatedTransaction = new Transaction
            {
                TransactionId = transactionId,
                Amount = amount,
                Category = category,
                Date = date,
            };

            this._inMemoryRepository.UpdateTransaction(oldTransaction, updatedTransaction);
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

            this._inMemoryRepository.DeleteTransaction(transaction);
            return true;
        }

        /// <summary>
        /// Calculates total income.
        /// </summary>
        /// <returns>Total income amount.</returns>
        public decimal GetTotalIncome()
        {
            decimal totalIncome = 0;
            List<Transaction> transactions = this._inMemoryRepository.LoadTransactions();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount > 0)
                {
                    totalIncome += transaction.Amount;
                }
            }

            return totalIncome;
        }

        /// <summary>
        /// Calculates total expense.
        /// </summary>
        /// <returns>Total expense amount.</returns>
        public decimal GetTotalExpense()
        {
            decimal totalExpense = 0;
            List<Transaction> transactions = this._inMemoryRepository.LoadTransactions();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount < 0)
                {
                    totalExpense += Math.Abs(transaction.Amount);
                }
            }

            return totalExpense;
        }

        /// <summary>
        /// Calculates net balance.
        /// </summary>
        /// <returns>Net balance amount.</returns>
        public decimal GetNetBalance()
        {
            return this.GetTotalIncome() - this.GetTotalExpense();
        }
    }
}

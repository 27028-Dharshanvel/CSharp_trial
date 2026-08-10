using Assignment4.Helpers;
using Assignment4.Models;
using Assignment4.Repository;
using Assignment4.Services;
using ConsoleTables;

namespace Assignment4.Views
{
    /// <summary>
    /// Transaction Menu.
    /// </summary>
    internal static class TransactionMenu
    {
        /// <summary>
        /// Displays Transaction Menu with specified service.
        /// </summary>
        /// <param name="service">Transaction service instance.</param>
        /// <param name="userId">Guid for users.</param>
        public static void DisplayTransactionMenu(TransactionService service, Guid userId)
        {
            bool inTransactionMenu = true;
            Guid currentUserId = userId;
            while (inTransactionMenu)
            {
                Console.WriteLine("\n================Transaction Menu====================");
                Console.WriteLine(@"1.Add transaction
2.View transactions
3.Edit transaction
4.Delete transaction
5.View Stats
6.Log out");
                int rawChoice = InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 7, 3, -1);
                if (rawChoice == -1)
                {
                    continue;
                }

                if (rawChoice == 6)
                {
                    InputReader.Success("Logged out successfully.");
                    break;
                }

                TransactionMenuEnum choice = (TransactionMenuEnum)rawChoice;
                switch (choice)
                {
                    case TransactionMenuEnum.AddTransaction:
                        AddTransactionHandler(service, currentUserId);
                        break;

                    case TransactionMenuEnum.ViewTransactions:
                        ViewTransactionsHandler(service, currentUserId);
                        break;

                    case TransactionMenuEnum.EditTransaction:
                        EditTransactionHandler(service, currentUserId);
                        break;

                    case TransactionMenuEnum.DeleteTransaction:
                        DeleteTransactionHandler(service, currentUserId);
                        break;

                    case TransactionMenuEnum.ViewStats:
                        ViewStatsHandler(service, currentUserId);
                        break;
                }
            }
        }

        private static void AddTransactionHandler(TransactionService service, Guid userId)
        {
            Console.WriteLine(@"
1.Add Income
2.Add expense");
            TransactionTypeEnum userChoice = (TransactionTypeEnum)InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 3, 3, -1);
            switch (userChoice)
            {
                case TransactionTypeEnum.AddIncome:
                    decimal incomeAmount = InputReader.ReadDecimal("Enter Income amount : ", "Amount", 1, 100000000, 3, -1);
                    if (incomeAmount == -1)
                    {
                        break;
                    }

                    DateOnly incomeDate = InputReader.GetValidDate("Enter date of transaction : ", 5, 3, default(DateOnly));
                    if (incomeDate == default(DateOnly))
                    {
                        break;
                    }

                    string incomeSource = InputReader.ReadString("Enter Source of Income : ", "Income Source", 15, 3, "@@@");
                    if (incomeSource == "@@@")
                    {
                        break;
                    }

                    service.AddTransaction(userId, incomeAmount, incomeSource, incomeDate);
                    InputReader.Success("Income transaction added successfully!");
                    break;

                case TransactionTypeEnum.AddExpense:
                    decimal expenseAmount = InputReader.ReadDecimal("Enter Expense amount : ", "Amount", 1, 100000000, 3, -1);
                    if (expenseAmount == -1)
                    {
                        break;
                    }

                    DateOnly expenseDate = InputReader.GetValidDate("Enter date of transaction : ", 5, 3, default(DateOnly));
                    if (expenseDate == default(DateOnly))
                    {
                        break;
                    }

                    string expenseCategory = InputReader.ReadString("Enter Expense Category : ", "Expense Category", 15, 3, "@@@");
                    if (expenseCategory == "@@@")
                    {
                        break;
                    }

                    service.AddTransaction(userId, -expenseAmount, expenseCategory, expenseDate);
                    InputReader.Success("Expense transaction added successfully!");
                    break;
            }
        }

        private static void ViewTransactionsHandler(TransactionService service, Guid userId)
        {
            List<Transaction> transactions = service.GetAllTransactions();
            if (transactions.Count == 0)
            {
                InputReader.Warn("No transactions found.");
                return;
            }

            ConsoleTable table = new ConsoleTable("Index", "Type", "Amount", "Category", "Date");
            int index = 1;
            foreach (Transaction transaction in transactions)
            {
                if (transaction.UserId == userId)
                {
                    string type = transaction.Amount >= 0 ? "Income" : "Expense";
                    decimal displayAmount = Math.Abs(transaction.Amount);
                    table.AddRow(index++, type, displayAmount.ToString("0.00"), transaction.Category, transaction.Date.ToString("yyyy-MM-dd"));
                }
            }

            Console.WriteLine();
            table.Write();
        }

        private static void EditTransactionHandler(TransactionService service, Guid userId)
        {
            List<Transaction> transactions = service.GetAllTransactions();
            if (transactions.Count == 0)
            {
                InputReader.Warn("No transactions found to edit.");
                return;
            }

            ViewTransactionsHandler(service, userId);
            int selectedIndex = InputReader.ReadInt("\nEnter transaction index to edit : ", "Index", 1, transactions.Count + 1, 3, -1);
            if (selectedIndex == -1)
            {
                return;
            }

            Transaction targetTransaction = transactions[selectedIndex - 1];
            bool isIncome = targetTransaction.Amount >= 0;
            string typeName = isIncome ? "Income" : "Expense";

            decimal newAmount = InputReader.ReadDecimal($"Enter new {typeName} amount : ", "Amount", 1, 100000000, 3, -1);
            if (newAmount == -1)
            {
                return;
            }

            DateOnly newDate = InputReader.GetValidDate("Enter new date of transaction : ", 5, 3, default(DateOnly));
            if (newDate == default(DateOnly))
            {
                return;
            }

            string newCategory = InputReader.ReadString($"Enter new {typeName} Category/Source : ", "Category", 15, 3, "@@@");
            if (newCategory == "@@@")
            {
                return;
            }

            decimal finalAmount = isIncome ? newAmount : -newAmount;
            if (service.UpdateTransaction(targetTransaction.TransactionId, finalAmount, newCategory, newDate))
            {
                InputReader.Success("Transaction updated successfully!");
            }
            else
            {
                InputReader.Error("Failed to update transaction.");
            }
        }

        private static void DeleteTransactionHandler(TransactionService service, Guid userId)
        {
            List<Transaction> transactions = service.GetAllTransactions();
            if (transactions.Count == 0)
            {
                InputReader.Warn("No transactions found to delete.");
                return;
            }

            ViewTransactionsHandler(service, userId);
            int selectedIndex = InputReader.ReadInt("\nEnter transaction index to delete : ", "Index", 1, transactions.Count + 1, 3, -1);
            if (selectedIndex == -1)
            {
                return;
            }

            Transaction targetTransaction = transactions[selectedIndex - 1];
            if (service.DeleteTransaction(targetTransaction.TransactionId))
            {
                InputReader.Success("Transaction deleted successfully!");
            }
            else
            {
                InputReader.Error("Failed to delete transaction.");
            }
        }

        private static void ViewStatsHandler(TransactionService service, Guid userId)
        {
            List<Transaction> transactions = service.GetAllTransactions();
            if (transactions.Count == 0)
            {
                InputReader.Warn("No transactions available to display stats.");
                return;
            }

            decimal totalIncome = service.GetTotalIncome(userId);
            decimal totalExpense = service.GetTotalExpense(userId);
            decimal netBalance = service.GetNetBalance(userId);

            ConsoleTable statsTable = new ConsoleTable("Metric", "Amount");
            statsTable.AddRow("Total Income", totalIncome.ToString("0.00"));
            statsTable.AddRow("Total Expense", totalExpense.ToString("0.00"));
            statsTable.AddRow("Net Balance", netBalance.ToString("0.00"));

            Console.WriteLine();
            statsTable.Write();
        }
    }
}

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
        /// Displays Transaction Menu.
        /// </summary>
        /// <param name="service">Transaction service instance.</param>
        /// <param name="userId">Guid of user.</param>
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
                int rawChoice = 0;
                if (!InputValidater.IsValidInt("\nEnter your choice : ", "Choice", 1, 7, 3, out rawChoice))
                {
                    inTransactionMenu = false;
                    Console.WriteLine("Logging out");
                    Console.ReadKey();
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

                    case TransactionMenuEnum.LogOut:
                        inTransactionMenu = false;
                        Console.WriteLine("Logging out");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AddTransactionHandler(TransactionService service, Guid userId)
        {
            Console.WriteLine(@"
1.Add Income
2.Add expense");
            int rawChoice = 0;
            if (!InputValidater.IsValidInt("\nEnter your choice : ", "Choice", 1, 3, 3, out rawChoice))
            {
                Console.WriteLine("Returning to Transaction menu...");
                Console.ReadKey();
                return;
            }

            TransactionTypeEnum userChoice = (TransactionTypeEnum)rawChoice;
            switch (userChoice)
            {
                case TransactionTypeEnum.AddIncome:
                    decimal incomeAmount;
                    if (!InputValidater.IsValidDecimal("Enter Income amount : ", "Amount", 1, 100000000, 3, out incomeAmount))
                    {
                        Console.WriteLine("Returning to Transaction menu...");
                        Console.ReadKey();
                        return;
                    }

                    DateOnly incomeDate;
                    if (!InputValidater.IsValidDate("Enter date of transaction : ", 5, 3, out incomeDate))
                    {
                        Console.WriteLine("Returning to Transaction menu...");
                        Console.ReadKey();
                        return;
                    }

                    string incomeSource;
                    if (!InputValidater.IsValidString("Enter Source of Income : ", "Income Source", 15, 3, out incomeSource))
                    {
                            Console.WriteLine("Returning to Transaction menu...");
                            Console.ReadKey();
                            return;
                    }

                    service.AddTransaction(userId, incomeAmount, incomeSource, incomeDate);
                    OutputColor.Success("Income transaction added successfully!");
                    break;

                case TransactionTypeEnum.AddExpense:
                    decimal expenseAmount;
                    if (!InputValidater.IsValidDecimal("Enter Expense amount : ", "Amount", 1, 100000000, 3, out expenseAmount))
                    {
                        Console.WriteLine("Returning to Transaction menu...");
                        Console.ReadKey();
                        return;
                    }

                    DateOnly expenseDate;
                    if (!InputValidater.IsValidDate("Enter date of transaction : ", 5, 3, out expenseDate))
                    {
                        Console.WriteLine("Returning to Transaction menu...");
                        Console.ReadKey();
                        return;
                    }

                    string expenseCategory;
                    if (!InputValidater.IsValidString("Enter Expense Category : ", "Expense Category", 15, 3, out expenseCategory))
                    {
                        Console.WriteLine("Returning to Transaction menu...");
                        Console.ReadKey();
                        return;
                    }

                    service.AddTransaction(userId, -expenseAmount, expenseCategory, expenseDate);
                    OutputColor.Success("Expense transaction added successfully!");
                    break;

                case TransactionTypeEnum.Back:
                    Console.WriteLine("Returning to Transaction menu...");
                    Console.ReadKey();
                    return;
            }
        }

        private static void ViewTransactionsHandler(TransactionService service, Guid userId)
        {
            List<Transaction> transactions = service.GetAllTransactions();
            if (transactions.Count == 0)
            {
                OutputColor.Warn("No transactions found.");
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
                OutputColor.Warn("No transactions found to edit.");
                return;
            }

            ViewTransactionsHandler(service, userId);
            int selectedIndex;
            if (!InputValidater.IsValidInt("\nEnter transaction index to edit : ", "Index", 1, transactions.Count + 1, 3, out selectedIndex))
            {
                Console.WriteLine("Returning to Transaction menu...");
                Console.ReadKey();
                return;
            }

            Transaction targetTransaction = transactions[selectedIndex - 1];
            bool isIncome = targetTransaction.Amount >= 0;
            string typeName = isIncome ? "Income" : "Expense";

            decimal newAmount;
            if (!InputValidater.IsValidDecimal($"Enter new {typeName} amount : ", "Amount", 1, 100000000, 3, out newAmount))
            {
                Console.WriteLine("Returning to Transaction menu...");
                Console.ReadKey();
                return;
            }

            DateOnly newDate;
            if (!InputValidater.IsValidDate("Enter new date of transaction : ", 5, 3, out newDate))
            {
                Console.WriteLine("Returning to Transaction menu...");
                Console.ReadKey();
                return;
            }

            string newCategory;
            if (!InputValidater.IsValidString($"Enter new {typeName} Category/Source : ", "Category", 15, 3, out newCategory))
            {
                Console.WriteLine("Returning to Transaction menu...");
                Console.ReadKey();
                return;
            }

            decimal finalAmount = isIncome ? newAmount : -newAmount;
            if (service.UpdateTransaction(targetTransaction.TransactionId, finalAmount, newCategory, newDate))
            {
                OutputColor.Success("Transaction updated successfully!");
            }
            else
            {
                OutputColor.Error("Failed to update transaction.");
            }
        }

        private static void DeleteTransactionHandler(TransactionService service, Guid userId)
        {
            List<Transaction> transactions = service.GetAllTransactions();
            if (transactions.Count == 0)
            {
                OutputColor.Warn("No transactions found to delete.");
                return;
            }

            ViewTransactionsHandler(service, userId);
            int selectedIndex;
            if (!InputValidater.IsValidInt("\nEnter transaction index to delete : ", "Index", 1, transactions.Count + 1, 3, out selectedIndex))
            {
                Console.WriteLine("Returning to Transaction menu...");
                Console.ReadKey();
                return;
            }

            Transaction targetTransaction = transactions[selectedIndex - 1];
            if (service.DeleteTransaction(targetTransaction.TransactionId))
            {
                OutputColor.Success("Transaction deleted successfully!");
            }
            else
            {
                OutputColor.Error("Failed to delete transaction.");
            }
        }

        private static void ViewStatsHandler(TransactionService service, Guid userId)
        {
            List<Transaction> transactions = service.GetAllTransactions();
            if (transactions.Count == 0)
            {
                OutputColor.Warn("No transactions available to display stats.");
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

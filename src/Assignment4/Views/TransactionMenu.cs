using Assignment2.Helpers;
using Assignment4.Models;

namespace Assignment4.Views
{
    /// <summary>
    /// Transaction Menu
    /// </summary>
    internal static class TransactionMenu
    {
        /// <summary>
        /// Displays Transaction Menu
        /// </summary>
        public static void DisplayTransactionMenu()
        {
            Console.WriteLine(@"1.Add transaction
2.View transactions
3.Edit transaction
4.Delete transaction
5.View Stats");
            TransactionMenuEnum choice = (TransactionMenuEnum)InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 6, 3, -1);
            switch (choice)
            {
                case TransactionMenuEnum.AddTransaction:
                    Console.WriteLine(@"1.Add Income
2.Add expense");
                    TransactionTypeEnum userChoice = (TransactionTypeEnum)InputReader.ReadInt("\nEnter yout choice : ", "Choice", 1, 3, 3, -1);
                    switch (userChoice)
                    {
                        case TransactionTypeEnum.AddIncome:
                            decimal incomeAmount = InputReader.ReadDecimal("Enter Income amount : ", "Amount", 1, 100000000, 3, -1);
                            DateOnly incomeDate = InputReader.GetValidDate("Enter date of transaction : ", 5, 3, default(DateOnly));
                            string incomeSource = InputReader.ReadString("Enter Source of Income : ", "Income Source", 15, 3, "@@@");
                            break;

                        case TransactionTypeEnum.AddExpense:
                            decimal expenseAmount = InputReader.ReadDecimal("Enter Income amount : ", "Amount", 1, 100000000, 3, -1);
                            DateOnly expenseDate = InputReader.GetValidDate("Enter date of transaction : ", 5, 3, default(DateOnly));
                            string expenseCategory = InputReader.ReadString("Enter Source of Income : ", "Income Source", 15, 3, "@@@");
                            break;
                    }

                    break;
            }
        }
    }
}

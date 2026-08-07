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
                    Console.WriteLine(""
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.View
{
    /// <summary>
    /// Console input and output operations
    /// </summary>
    internal static class ConsoleView
    {
        /// <summary>
        /// Console Operations
        /// </summary>
        public static void ConsoleOperations()
        {
            Console.WriteLine("********* Inventory Management Application ************" +
                "\n\nEnter the operation to perform : " +
                "\n1.Add products" +
                "\n2.View Products" +
                "\n3.Edit product" + 
                "\n4.Delete Product");
            Console.ReadLine();
        }
    } 
}

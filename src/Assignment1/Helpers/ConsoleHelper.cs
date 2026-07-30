using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagerApp.Models;

namespace ContactManagerApp.Helpers
{
    /// <summary>
    /// ConsoleHelper
    /// </summary>
    internal class ConsoleHelper
    {
        /// <summary>
        /// Adds contact details
        /// </summary>
        /// <returns>Contact object</returns>
        public static Contact AddContactDetails()
        {
            Contact contact = new Contact();
            Console.Write("Name: ");
            contact.Name =
                Console.ReadLine() ?? string.Empty;

            Console.Write("Phone Number: ");
            contact.PhoneNumber =
                Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            contact.Email =
                Console.ReadLine() ?? string.Empty;

            Console.Write("Notes: ");
            contact.Notes =
                Console.ReadLine() ?? string.Empty;
            return contact;
        }
    }
}

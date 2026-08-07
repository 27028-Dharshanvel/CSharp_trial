using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assignment4.Services
{
    /// <summary>
    /// Service Class
    /// </summary>
    internal class Service
    {
        /// <summary>
        /// Adds Transaction to the repository.
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="category">category</param>
        /// <param name="date">date</param>
        /// <returns>True if transaction is added, False if error.</returns>
        public bool AddTransaction(decimal amount, string category, DateOnly date)
        {
            
        }
    }
}

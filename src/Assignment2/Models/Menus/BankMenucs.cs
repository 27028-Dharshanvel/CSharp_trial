using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    /// <summary>
    /// BankMenu
    /// </summary>
    public enum BankMenu
    {
        /// <summary>
        /// CreateAccount
        /// </summary>
        CreateAccount = 1,

        /// <summary>
        /// ViewAccountDetails
        /// </summary>
        ViewAccountDetails,

        /// <summary>
        /// DepositAmount
        /// </summary>
        DepositAmount,

        /// <summary>
        /// WithdrawAmount
        /// </summary>
        WithdrawAmount,

        /// <summary>
        /// Back
        /// </summary>
        Back,
    }
}

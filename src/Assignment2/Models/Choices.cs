using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    /// <summary>
    /// Choices
    /// </summary>
    internal class Choices
    {
        /// <summary>
        /// Enum for Mainmenu
        /// </summary>
        public enum MainMenu
        {
            /// <summary>
            /// shape
            /// </summary>
            Shape = 1,

            /// <summary>
            /// Employee
            /// </summary>
            Employee,

            /// <summary>
            /// BankAccount
            /// </summary>
            BankAccount,

            /// <summary>
            /// exit
            /// </summary>
            Exit,
        }

        /// <summary>
        /// ShapeMenu
        /// </summary>
        public enum ShapeMenu
        {
            /// <summary>
            /// Rectangle
            /// </summary>
            Rectangle = 1,

            /// <summary>
            /// Circle
            /// </summary>
            Circle,

            /// <summary>
            /// Back
            /// </summary>
            Back,
        }

        /// <summary>
        /// EmployeeMenu
        /// </summary>
        public enum EmployeeMenu
        {
            /// <summary>
            /// Manager
            /// </summary>
            Manager = 1,

            /// <summary>
            /// Developer
            /// </summary>
            Developer,

            /// <summary>
            /// Back
            /// </summary>
            Back,
        }

        /// <summary>
        /// BankMenu
        /// </summary>
        public enum BankMenu
        {
            /// <summary>
            /// SavingsAccount
            /// </summary>
            SavingsAccount = 1,

            /// <summary>
            /// CheckingAccount
            /// </summary>
            CheckingAccount,

            /// <summary>
            /// Back
            /// </summary>
            Back,
        }

        /// <summary>
        /// BankingOperations Enumerator
        /// </summary>
        public enum BankingOperations
        {
            /// <summary>
            /// Deposit
            /// </summary>
            Deposit = 1,

            /// <summary>
            /// Withdraw
            /// </summary>
            Withdraw,
        }
    }
}

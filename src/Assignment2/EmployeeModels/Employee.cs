using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.EmployeeModels
{
    /// <summary>
    /// Employee
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name of Employee
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets salary
        /// </summary>
        /// <value>
        /// Salary
        /// </value>
        public int Salary { get; set; } = 0;

        /// <summary>
        /// Gets position of Employee
        /// </summary>
        /// <value>
        /// Position of Employee.
        /// </value>
        public abstract string Position { get; }

        /// <summary>
        /// CalculatesBonus
        /// </summary>
        /// <returns>Bonus amount</returns>
        public abstract int CalculateBonus();
    }
}

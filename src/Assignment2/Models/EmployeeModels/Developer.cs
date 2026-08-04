using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.EmployeeModels
{
    /// <summary>
    /// Developer
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// Gets position of the employee.
        /// </summary>
        /// <value>
        /// Position of Employee.
        /// </value>
        public override string Position
        {
            get
            {
                return "Developer";
            }
        }

        /// <summary>
        /// Calculates Bonus amount from salary.
        /// </summary>
        /// <returns> Bonus amount </returns>
        public override decimal CalculateBonus()
        {
            return this.Salary * 0.20m;
        }
    }
}

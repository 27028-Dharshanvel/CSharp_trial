using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.EmployeeModels
{
    /// <summary>
    /// Manager
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Gets position
        /// </summary>
        /// <value>
        /// Positionvof Employee
        /// </value>
        public override string Position
        {
            get
            {
                return "Manager";
            }
        }
        /// <summary>
        /// CAlculates Bonus
        /// </summary>
        /// <returns> Bonus amount </returns>
        public override decimal CalculateBonus()
        {
            return Salary * 0.20m;
        }
    }
}

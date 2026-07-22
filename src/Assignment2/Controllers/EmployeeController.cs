using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.EmployeeModels;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    internal class EmployeeController
    {
        /// <summary>
        /// Calculates Bonus
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>Bonus amount</returns>
        public decimal CalculateBonus(Employee employee)
        {
            return employee.CalculateBonus();
        }
    }
}

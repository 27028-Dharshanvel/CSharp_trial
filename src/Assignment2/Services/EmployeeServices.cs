using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.EmployeeModels;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Employee Services
    /// </summary>
    internal class EmployeeServices
    {
        /// <summary>
        /// Calculates bonus amount from the salary.
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>Bonus amount.</returns>
        public decimal CalculateBonus(Employee employee)
        {
            return employee.CalculateBonus();
        }
    }
}

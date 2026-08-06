namespace Assignment2.EmployeeModels
{
    /// <summary>
    /// Manager
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Calculates Bonus amount from the salary.
        /// </summary>
        /// <returns> Bonus amount </returns>
        public override decimal CalculateBonus()
        {
            return this.Salary * 0.30m;
        }
    }
}

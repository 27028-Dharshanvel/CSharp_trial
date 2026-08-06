namespace Assignment2.EmployeeModels
{
    /// <summary>
    /// Developer
    /// </summary>
    internal class Developer : Employee
    {
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

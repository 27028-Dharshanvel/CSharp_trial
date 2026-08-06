namespace Assignment2.EmployeeModels
{
    /// <summary>
    /// Employee
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Gets or sets name.
        /// </summary>
        /// <value>
        /// Name of Employee
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets salary.
        /// </summary>
        /// <value>
        /// Salary
        /// </value>
        public decimal Salary { get; set; } = 0;

        /// <summary>
        /// Calculates Bonus from the salary.
        /// </summary>
        /// <returns>Bonus amount</returns>
        public abstract decimal CalculateBonus();
    }
}

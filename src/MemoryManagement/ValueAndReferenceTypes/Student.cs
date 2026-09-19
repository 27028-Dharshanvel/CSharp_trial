namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Student class
    /// </summary>
    internal class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">Name of the student</param>
        public Student(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name of the student
        /// </value>
        public string? Name { get; set; }
    }
}

namespace GarbageCollection
{
    /// <summary>
    /// Student class
    /// </summary>
    internal class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="id">id</param>
        public Student(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets id
        /// </summary>
        /// <value>
        /// Id
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string? Name { get; set; }
    }
}

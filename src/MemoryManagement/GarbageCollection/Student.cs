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
        /// Gets or sets id of student
        /// </summary>
        /// <value>
        /// Id of the Student
        /// </value>
        public int Id { get; set; }
    }
}

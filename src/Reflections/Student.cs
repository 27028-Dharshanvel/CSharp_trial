namespace Reflections
{
    /// <summary>
    /// student class
    /// </summary>
    internal class Student
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value>
        /// Grade
        /// </value>
        public string Name { get; set; } = "D vel";

        /// <summary>
        /// Gets or sets age
        /// </summary>
        /// <value>
        /// Grade
        /// </value>
        public int Age { get; set; } = 20;

        /// <summary>
        /// Gets or sets grade
        /// </summary>
        /// <value>
        /// Grade
        /// </value>
        public double Grade { get; set; } = 88.5;

        /// <summary>
        /// Hello function
        /// </summary>
        public void SayHello()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }

        /// <summary>
        /// Displays details
        /// </summary>
        /// <param name="message">message</param>
        public void DisplayDetails(string message)
        {
            Console.WriteLine($"Message: {message} | Student: {Name}, Age: {Age}, Grade: {Grade}");
        }
    }
}

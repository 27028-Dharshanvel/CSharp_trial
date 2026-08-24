namespace Assignments
{

    /// <summary>
    /// Custom exception for invalid user input.
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}
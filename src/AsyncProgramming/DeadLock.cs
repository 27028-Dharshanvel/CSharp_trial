namespace AsyncProgramming
{
    /// <summary>
    /// Class consisting of methods to demonstrate and resolve deadlock conditions.
    /// </summary>
    public static class DeadLock
    {
        /// <summary>
        /// Calls and returns the result of some asynchronous operation without causing a deadlock.
        /// </summary>
        /// <returns>Task of string.</returns>
        public static async Task<string> DeadlockMethod()
        {
            var result = await SomeAsyncOperation();
            return result;
        }

        /// <summary>
        /// Creates a delay for one second and returns a string.
        /// </summary>
        /// <returns>String message.</returns>
        public static async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello World!";
        }
    }
}
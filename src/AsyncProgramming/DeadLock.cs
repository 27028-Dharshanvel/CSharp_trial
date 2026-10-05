namespace AsyncProgramming
{
        /// <summary>
        /// Provides methods to understand the concepts of deadlock.
        /// </summary>
        /// <summary>
        /// Class consisting of a method that prints a string to the console prone to deadlock.
        /// </summary>
        public static class DeadLock
        {
            /// <summary>
            /// Calls and returns the result of some asynchronous operation.
            /// </summary>
            /// <returns>Task of string.</returns>
            public static async Task<string> DeadlockMethod()
            {
                var result = await SomeAsyncOperation();
                return result;
            }

            /// <summary>
            /// Creates a delay for one second and return a string.
            /// </summary>
            /// <returns>String message.</returns>
            public static async Task<string> SomeAsyncOperation()
            {
                await Task.Delay(1000);
                return "Hello World!";
            }
        }
}

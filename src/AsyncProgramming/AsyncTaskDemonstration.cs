namespace AsyncProgramming
{
    /// <summary>
    /// Demonstrates various asynchronous programming, TPL, and multithreading concepts.
    /// </summary>
    public static class AsyncTaskDemonstration
    {
        /// <summary>
        /// Downloads content from a URL asynchronously using HttpClient.
        /// </summary>
        /// <returns>Task returning string content.</returns>
        public static async Task<string> GetHttpContent()
        {
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://www.solitontech.com/dot-net-development-services");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request failed: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Generates an integer array from 1 to 10000.
        /// </summary>
        /// <returns>Integer array.</returns>
        public static int[] ArrayGenerate()
        {
            int[] array = new int[10000];

            for (int i = 0; i < 10000; i++)
            {
                array[i] = i + 1;
            }

            return array;
        }

        /// <summary>
        /// Uses Parallel.ForEach from TPL to square each number in the array.
        /// </summary>
        /// <param name="array">Integer array.</param>
        public static void SquareArray(int[] array)
        {
            Parallel.ForEach(array, value =>
            {
                Console.WriteLine($"Value: {value}, Square: {(long)value * value}");
            });
        }

        /// <summary>
        /// Sorts an array using bubble sort algorithm.
        /// </summary>
        /// <param name="array">Integer array.</param>
        public static void SortsArray(int[] array)
        {
            int n = array.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Performs mathematical calculations.
        /// </summary>
        /// <returns>Integer math result.</returns>
        public static int MathTask()
        {
            int x = 123, y = 20, z = 2343, a = 45346, b = 76362, c = 53698423;

            int result = x - b + (a * z * c) + (y * x * y) + (z * z);

            return result;
        }

        /// <summary>
        /// Simulates a CPU-bound operation started with Task.Run().
        /// </summary>
        /// <returns>Task returning an integer result.</returns>
        public static Task<int> MethodA()
        {
            return Task.Run(() =>
            {
                int x = 123, y = 20, z = 2343, a = 45346, b = 76362, c = 53698423;
                int result = Math.Abs((x - b + (a * z * c) + (y * x * y) + (z * z)) % 100);
                return result;
            });
        }

        /// <summary>
        /// Simulates an async web service call using HttpClient, using the result from MethodA to construct the request.
        /// </summary>
        /// <returns>Task returning the web service response string.</returns>
        public static async Task<string> MethodB()
        {
            using HttpClient client = new HttpClient();
            int calculationResult = await MethodA();
            string url = $"https://jsonplaceholder.typicode.com/todos/{calculationResult + 1}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"{{\"id\": {calculationResult + 1}, \"status\": \"simulated_fallback\", \"error\": \"{ex.Message}\"}}";
            }
        }

        /// <summary>
        /// Calls MethodB, awaits its result, and processes the JSON response.
        /// </summary>
        /// <returns>Task returning the processed string result.</returns>
        public static async Task<string> MethodC()
        {
            string jsonResponse = await MethodB();
            int keyCount = jsonResponse.Split(':').Length - 1;
            return $"Processed Response (Length: {jsonResponse.Length} chars, Extracted key count: {keyCount}):\n{jsonResponse}";
        }

        /// <summary>
        /// Simulates a long-running operation using Task.Delay with ConfigureAwait(false) and thread tracking.
        /// </summary>
        /// <returns>Task returning status message.</returns>
        public static async Task<string> SimulateComplexOperationA()
        {
            Console.WriteLine($"MethodA before await - Managed Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2000).ConfigureAwait(false);
            Console.WriteLine($"MethodA after await - Managed Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return "Operation A finished.";
        }

        /// <summary>
        /// Calls SimulateComplexOperationA, awaits its result, and performs further processing.
        /// </summary>
        /// <returns>Task returning processing result.</returns>
        public static async Task<string> SimulateComplexOperationB()
        {
            Console.WriteLine($"MethodB before calling MethodA - Managed Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            string resultA = await SimulateComplexOperationA();
            Console.WriteLine($"MethodB after awaiting MethodA - Managed Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"{resultA} -> MethodB further processing complete.";
        }

        /// <summary>
        /// Async void method that throws an exception.
        /// </summary>
        public static async void VoidMethod()
        {
            await Task.Delay(500);
            throw new InvalidOperationException("Exception thrown from async void method!");
        }

        /// <summary>
        /// Async Task method that throws an exception.
        /// </summary>
        /// <returns>Task.</returns>
        public static async Task TaskMethod()
        {
            await Task.Delay(500);
            throw new InvalidOperationException("Exception thrown from async Task method!");
        }

        /// <summary>
        /// Downloads content from URL asynchronously and displays it.
        /// </summary>
        /// <returns>Task</returns>
        public static async Task TaskOne()
        {
            Console.WriteLine("Task 1: Downloading content...");
            string content = await GetHttpContent();
            Console.WriteLine($"Downloaded Content:\n{content}");
        }

        /// <summary>
        /// Demonstrates Parallel.ForEach from TPL.
        /// </summary>
        public static void TaskTwo()
        {
            Console.WriteLine("Task 2: Squaring array elements using TPL Parallel.ForEach...");
            int[] array = ArrayGenerate();
            SquareArray(array);
        }

        /// <summary>
        /// Demonstrates multi-threading using Thread class and Join, then combining results.
        /// </summary>
        public static void TaskThree()
        {
            Console.WriteLine("Task 3: Running multi-threaded operations and combining results...");
            int mathResult = 0;
            int[] array = ArrayGenerate();
            Thread t1 = new Thread(() => SortsArray(array));
            Thread t2 = new Thread(() => { mathResult = MathTask(); });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Combined Multithreading Results:\n- Math Task Result: {mathResult}\n- Sorted Array First Element: {array[0]}, Last Element: {array[array.Length - 1]}");
        }

        /// <summary>
        /// Multi-layered async/await operations with root Task.Run().
        /// </summary>
        /// <returns>Task</returns>
        public static async Task TaskFour()
        {
            Console.WriteLine("Task 4: Running multi-layered async operations...");
            string result = await MethodC();
            Console.WriteLine($"Final Output from MethodC:\n{result}");
        }

        /// <summary>
        /// Debugging and fixing deadlock condition.
        /// </summary>
        /// <returns>Task</returns>
        public static async Task TaskFive()
        {
            Console.WriteLine("Task 5: Running non-deadlocking async operation...");
            string result = await DeadLock.DeadlockMethod();
            Console.WriteLine($"Output: {result}");
        }

        /// <summary>
        /// ConfigureAwait(false) application with thread tracking.
        /// </summary>
        /// <returns>Task</returns>
        public static async Task TaskSix()
        {
            Console.WriteLine("Task 6: Testing ConfigureAwait(false) with thread tracking...");
            string result = await SimulateComplexOperationB();
            Console.WriteLine($"Final Output: {result}");
        }

        /// <summary>
        /// Task 7: Async void vs Async Task error handling demonstration.
        /// </summary>
        /// <returns>Task</returns>
        public static async Task TaskSeven()
        {
            Console.WriteLine("Task 7: Demonstrating Exception handling difference...");

            Console.WriteLine("\n[1] Testing async Task method:");
            try
            {
                await TaskMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Successfully caught exception from async Task method: {ex.Message}");
            }

            Console.WriteLine("\n[2] Testing async void method:");
            try
            {
                VoidMethod();
                Console.WriteLine("VoidMethod invoked asynchronously. Exceptions in async void methods propagate to synchronization context and cannot be caught by caller try-catch.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"This block will not catch async void exception: {ex.Message}");
            }
        }
    }
}
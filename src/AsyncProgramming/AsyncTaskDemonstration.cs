namespace AsyncProgramming
{
    /// <summary>
    /// Asynchronous tasks
    /// </summary>
    public static class AsyncTaskDemonstration
    {
        /// <summary>
        /// Gets Http Contents
        /// </summary>
        /// <returns>Task</returns>
        public static async Task<string> GetHttpContent()
        {
            HttpClient client = new HttpClient();
            try
            {
                // 1. Send the HTTP GET request
                HttpResponseMessage response = await client.GetAsync("https://www.solitontech.com/dot-net-development-services");

                // 2. Throw an exception if the status code is not 2xx
                response.EnsureSuccessStatusCode();

                // 3. Read the content as a string
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
        /// Generates array
        /// </summary>
        /// <returns>array</returns>
        public static int[] ArrayGenerate()
        {
            int[] array = new int[1000];

            for (int i = 0; i < 1000; i++)
            {
                array[i] = i;
            }

            return array;
        }

        /// <summary>
        /// Sorts array
        /// </summary>
        /// <param name="array">array</param>
        public static void SquareArray(int[] array)
        {
            Parallel.ForEach(array, value =>
            {
                lock (Console.Out)
                {
                    Console.WriteLine(value * value);
                }
            });
        }

        /// <summary>
        /// Sorts array
        /// </summary>
        /// <param name="array">array</param>
        public static void SortsArray(int[] array)
        {
            int n = array.Length;
            bool swapped;

            // Outer loop for the number of passes
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                // Inner loop compares adjacent elements
                // 'n - i - 1' ensures we ignore the elements that have already bubbled up
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap elements using a temporary variable
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        swapped = true;
                    }
                }

                // Optimization: If no elements were swapped, the array is already sorted
                if (!swapped)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// MAthtask
        /// </summary>
        /// <returns>int</returns>
        public static int MathTask()
        {
            int x = 123, y = 20, z = 2343, a = 45346, b = 76362, c = 53698423;

            int result = x - b + (a * z * c) + (y * x * y) + (z * z);

            return result;
        }

        /// <summary>
        /// Method A
        /// </summary>
        /// <returns>Task</returns>
        public static async Task<int> MethodA()
        {
            int x = 123, y = 20, z = 2343, a = 45346, b = 76362, c = 53698423;

            int result = x - b + (a * z * c) + (y * x * y) + (z * z);

            return result;
        }

        /// <summary>
        /// Method B
        /// </summary>
        /// <returns>Task</returns>
        public static async Task MethodB()
        {
            HttpClient client = new HttpClient();
            int result = await MethodA();
            await client.GetAsync("https://www.solitontech.com/dot-net-development-services");
        }

        /// <summary>
        /// Method C
        /// </summary>
        /// <returns>Task</returns>
        public static async Task MethodC()
        {
            await MethodB();
        }

        /// <summary>
        /// Simulates Complex Operations A
        /// </summary>
        /// <returns>Task</returns>
        public static async Task SimulateComplexOperationA()
        {
            await Task.Delay(5000).ConfigureAwait(false);
        }

        /// <summary>
        /// Simulates Complex operations
        /// </summary>
        /// <returns>Task</returns>
        public static async Task SimulateComplexOperationB()
        {
            await SimulateComplexOperationA();
            await Task.Delay(7000);
        }

        /// <summary>
        /// Async void method
        /// </summary>
        /// <exception cref="NotImplementedException">Sample exception</exception>
        public static async void VoidMethod()
        {
            await Task.Delay(2000);
            throw new Exception();
        }

        /// <summary>
        /// Task method that implements tasks.
        /// </summary>
        /// <returns>Task</returns>
        public static async Task TaskMethod()
        {
            await Task.Delay(2000);
            throw new Exception();
        }

        /// <summary>
        /// GetsHttpContent
        /// </summary>
        public static void TaskOne()
        {
            GetHttpContent();
        }

        /// <summary>
        /// GetsHttpContent
        /// </summary>
        public static void TaskTwo()
        {
            int[] array = ArrayGenerate();
            SquareArray(array);
        }

        /// <summary>
        /// GetsHttpContent
        /// </summary>
        public static void TaskThree()
        {
            int mathResult = 0;
            int[] array = ArrayGenerate();
            Thread t1 = new Thread(() => SortsArray(array));
            Thread t2 = new Thread(() => { mathResult = MathTask(); });

            // 2. Start the threads (Capital 'S')
            t1.Start();
            t2.Start();

            // 3. Wait for both threads to complete (Capital 'J' on the instances)
            t1.Join();
            t2.Join();

            Console.WriteLine(mathResult);
        }

        /// <summary>
        /// GetsHttpContent
        /// </summary>
        public static void TaskFour()
        {
            MethodC();
        }

        /// <summary>
        /// GetsHttpContent
        /// </summary>
        public static void TaskFive()
        {
            DeadLock.DeadlockMethod();
        }

        /// <summary>
        /// GetsHttpContent
        /// </summary>
        public static void TaskSix()
        {
            SimulateComplexOperationB();
        }

        /// <summary>
        /// GetsHttpContent
        /// </summary>
        public static void TaskSeven()
        {
            try
            {
                TaskMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is caught in Task returning method.");
            }

            try
            {
                VoidMethod();
            }
            catch(Exception ex)
            {
                Console.WriteLine("This will never be caught");
            }
        }
    }
}

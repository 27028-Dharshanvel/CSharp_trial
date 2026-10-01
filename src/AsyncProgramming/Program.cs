namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args">CMD line args</param>
        /// <returns>Task</returns>
        public static async Task Main(string[] args)
        {
            ArrayGenerate();
            //HttpClient client = new HttpClient();
            //try
            //{
            //    // 1. Send the HTTP GET request
            //    HttpResponseMessage response = await client.GetAsync("https://www.solitontech.com/dot-net-development-services");

            //    // 2. Throw an exception if the status code is not 2xx
            //    response.EnsureSuccessStatusCode();

            //    // 3. Read the content as a string
            //    string responseBody = await response.Content.ReadAsStringAsync();

            //    Console.WriteLine(responseBody);
            //}
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine($"Request failed: {e.Message}");
            //}
        }

        /// <summary>
        /// Generates array
        /// </summary>
        public static void ArrayGenerate()
        {
            int[] array = new int[1000];

            for (int i = 0; i < 1000; i++)
            {
                array[i] = i;
            }

            Parallel.ForEach(array, value =>
            {
                lock (Console.Out)
                {
                    Console.WriteLine(value * value);
                }
            });
        }
    }
}
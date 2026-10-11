namespace Reflections
{
    /// <summary>
    /// GreetingPlugin
    /// </summary>
    internal class GreetingPlugin
    {
        /// <summary>
        /// Gets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Name => "Greeting Plugin";

        /// <summary>
        /// Execution method
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("[GreetingPlugin] Hello from the dynamically loaded plugin!");
        }
    }
}

using EventsAndDelegates;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">CMD line args</param>
        public static void Main(string[] args)
        {
            // 4. Create an instance of the Notifier class
            Notifier notifier = new Notifier();

            // 5. Subscribe to the OnAction event using a lambda expression or method
            notifier.OnAction += DisplayMessage;

            // 6. Trigger the OnAction event with a string message
            Console.WriteLine("Triggering event...");
            notifier.TriggerAction("Hello! The event has been successfully triggered.");

            Console.ReadLine();
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine("Notification is recieved");
        }
    }
}
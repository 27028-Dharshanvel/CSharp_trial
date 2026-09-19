namespace EventsAndDelegates
{
    /// <summary>
    /// NotificationService
    /// </summary>
    internal class Notifier
    {
        // 2. Define the delegate that accepts a string and returns void

        /// <summary>
        /// Notify delegate.
        /// </summary>
        /// <param name="message">message</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Onaction event
        /// </summary>
        // 3. Define the event based on the Notify delegate
        public event Notify OnAction;

        // Method to trigger/raise the event safely

        /// <summary>
        /// Triggers action
        /// </summary>
        /// <param name="message">message</param>
        public void TriggerAction(string message)
        {
            // Check if there are any subscribers before invoking
            this.OnAction?.Invoke(message);
        }
    }
}

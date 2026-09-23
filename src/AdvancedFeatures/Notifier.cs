namespace AdvancedFeatures
{
    /// <summary>
    /// Notifier
    /// </summary>
    internal class Notifier
    {
        /// <summary>
        /// delegate for notifying
        /// </summary>
        /// <param name="message">message</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Event for action
        /// </summary>
        public event Notify OnAction;

        /// <summary>
        /// Performs the action
        /// </summary>
        public void PerformAction()
        {
            // Trigger the event
            if (OnAction != null)
            {
                OnAction("Action has been performed.");
            }
        }
    }
}

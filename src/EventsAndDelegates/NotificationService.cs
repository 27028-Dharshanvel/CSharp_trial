using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    /// <summary>
    /// NotificationService
    /// </summary>
    internal class NotificationService
    {
        /// <summary>
        /// Notification delegate
        /// </summary>
        /// <param name="message">message</param>
        public delegate void Notify(string message);

        public event Notify OnNotify;
    }
}

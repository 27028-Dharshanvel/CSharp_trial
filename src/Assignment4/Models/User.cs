using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    /// <summary>
    /// User class.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Gets or sets user Id.
        /// </summary>
        /// <value>User Id.</value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        /// <value>User name.</value>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        /// <value>Password hash.</value>
        public string? Password { get; set; }
    }
}

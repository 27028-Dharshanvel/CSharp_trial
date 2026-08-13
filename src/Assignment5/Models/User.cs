using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    /// <summary>
    /// Represents user model.
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
    }
}

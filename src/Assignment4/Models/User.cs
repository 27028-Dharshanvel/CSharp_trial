using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    /// <summary>
    /// Represents user model.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.UserId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets user Id.
        /// </summary>
        /// <value>User Id.</value>
        public Guid UserId { get; init; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        /// <value>User name.</value>
        public string UserName { get; set; }
    }
}

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

        /// <summary>
        /// Clone method to copy and return users.
        /// </summary>
        /// <returns>User</returns>
        public User Clone()
        {
            return new User()
            {
                UserId = this.UserId,
                UserName = this.UserName,
            };
        }
    }
}

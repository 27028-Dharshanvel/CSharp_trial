namespace Assignment4.Services
{
    /// <summary>
    /// Interface for UserServices
    /// </summary>
    internal interface IUserService
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="errorMessage">Error message if registration fails.</param>
        /// <returns>True if registration is successful; otherwise false.</returns>
        public bool RegisterUser(string username, out string errorMessage);

        /// <summary>
        /// User credentials.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="userId">User Id.</param>
        /// <returns>True if login is successful; otherwise false.</returns>
        public bool LoginUser(string username, out Guid userId);
    }
}

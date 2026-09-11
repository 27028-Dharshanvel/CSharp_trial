using Assignment4.Models;
using Assignment4.Repository;

namespace Assignment4.Services
{
    /// <summary>
    /// Service for managing user accounts.
    /// </summary>
    internal class UserService : IUserService
    {
        private IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">Instance of User repository.</param>
        public UserService(IUserRepository repository)
        {
            this._userRepository = repository;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="errorMessage">Error message if registration fails.</param>
        /// <returns>True if registration is successful; otherwise false.</returns>
        public bool RegisterUser(string username, out string errorMessage)
        {
            errorMessage = string.Empty;

            foreach (User existingUser in this._userRepository.LoadUsers())
            {
                if (string.Equals(existingUser.UserName, username, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = "Username already exists. Please choose a different username.";
                    return false;
                }
            }

            User newUser = new User
            {
                UserId = Guid.NewGuid(),
                UserName = username,
            };

            this._userRepository.AddUser(newUser);
            return true;
        }

        /// <summary>
        /// User credentials.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="userId">User Id.</param>
        /// <returns>True if login is successful; otherwise false.</returns>
        public bool LoginUser(string username, out Guid userId)
        {
            foreach (User existingUser in this._userRepository.LoadUsers())
            {
                if (string.Equals(existingUser.UserName, username, StringComparison.OrdinalIgnoreCase))
                {
                    userId = existingUser.UserId;
                    return true;
                }
            }

            userId = default(Guid);
            return false;
        }
    }
}

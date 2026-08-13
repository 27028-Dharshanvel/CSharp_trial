using System;
using System.Collections.Generic;
using Assignment5.Helpers;
using Assignment5.Models;
using Assignment5.Repository;

namespace Assignment5.Services
{
    /// <summary>
    /// Service for managing user accounts.
    /// </summary>
    internal class UserService
    {
        private IUserRepository _inMemoryUserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">repository.</param>
        public UserService(IUserRepository repository)
        {
            this._inMemoryUserRepository = repository;
        }

        /// <summary>
        /// Registers a new user with hashed password.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="errorMessage">Error message if registration fails.</param>
        /// <returns>True if registration is successful; otherwise false.</returns>
        public bool RegisterUser(string username, out string errorMessage)
        {
            errorMessage = string.Empty;

            foreach (User existingUser in this._inMemoryUserRepository.LoadUsers())
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

            this._inMemoryUserRepository.AddUser(newUser);
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
            foreach (User existingUser in this._inMemoryUserRepository.LoadUsers())
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

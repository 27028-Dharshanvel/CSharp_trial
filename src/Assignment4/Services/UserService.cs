using System;
using System.Collections.Generic;
using Assignment4.Helpers;
using Assignment4.Models;

namespace Assignment4.Services
{
    /// <summary>
    /// Service for managing user accounts and authentication.
    /// </summary>
    internal class UserService
    {
        private List<User> _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
        {
            this._users = new List<User>();
        }

        /// <summary>
        /// Registers a new user with hashed password.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">Plain text password.</param>
        /// <param name="errorMessage">Error message if registration fails.</param>
        /// <returns>True if registration is successful; otherwise false.</returns>
        public bool RegisterUser(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(username))
            {
                errorMessage = "Username cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            foreach (User existingUser in this._users)
            {
                if (string.Equals(existingUser.UserName, username, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = "Username already exists. Please choose a different username.";
                    return false;
                }
            }

            string hashedPassword = PasswordHasher.HashPassword(password);
            User newUser = new User
            {
                UserId = Guid.NewGuid(),
                UserName = username,
                Password = hashedPassword,
            };

            this._users.Add(newUser);
            return true;
        }

        /// <summary>
        /// Authenticates user credentials.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">Plain text password.</param>
        /// <param name="user">The authenticated user if successful.</param>
        /// <returns>True if login is successful; otherwise false.</returns>
        public bool LoginUser(string username, string password, out User? user)
        {
            user = null;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            foreach (User existingUser in this._users)
            {
                if (string.Equals(existingUser.UserName, username, StringComparison.OrdinalIgnoreCase))
                {
                    if (existingUser.Password != null && PasswordHasher.VerifyPassword(password, existingUser.Password))
                    {
                        user = existingUser;
                        return true;
                    }

                    return false;
                }
            }

            return false;
        }
    }
}

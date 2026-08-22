using Assignment5.Models;

namespace Assignment5.Repository
{
    /// <summary>
    /// Interface for user repository.
    /// </summary>
    internal interface IUserRepository
    {
        /// <summary>
        /// Save users.
        /// </summary>
        /// <param name="users">List of Users.</param>
        void SaveUsers(List<User> users);

        /// <summary>
        /// Loads users.
        /// </summary>
        /// <returns>List of users.</returns>
        List<User> LoadUsers();

        /// <summary>
        /// Adds users.
        /// </summary>
        /// <param name="users">Instance of user.</param>
        void AddUser(User users);

        /// <summary>
        /// Deletes users.
        /// </summary>
        /// <param name="users">Instance of user.</param>
        void DeleteUser(User users);

        /// <summary>
        /// Updates users.
        /// </summary>
        /// <param name="oldUser">oldtUser instance.</param>
        /// <param name="updatedUser">updatedUser instance.</param>
        void UpdateUser(User oldUser, User updatedUser);
    }
}

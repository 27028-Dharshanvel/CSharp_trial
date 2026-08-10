using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Interface for user repository.
    /// </summary>
    internal interface IUserRepository
    {
        /// <summary>
        /// Save users.
        /// </summary>
        /// <param name="users">Users.</param>
        void SaveUsers(List<User> users);

        /// <summary>
        /// Loads users.
        /// </summary>
        /// <returns>List of users.</returns>
        List<User> LoadUsers();

        /// <summary>
        /// Adds users.
        /// </summary>
        /// <param name="users">users.</param>
        void AddUser(User users);

        /// <summary>
        /// Deletes users.
        /// </summary>
        /// <param name="users">users.</param>
        void DeleteUser(User users);

        /// <summary>
        /// Updates users.
        /// </summary>
        /// <param name="oldUser">oldtUser</param>
        /// <param name="updatedUser">updatedUser</param>
        void UpdateUser(User oldUser, User updatedUser);
    }
}

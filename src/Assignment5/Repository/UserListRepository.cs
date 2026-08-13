using Assignment5.Models;

namespace Assignment5.Repository
{
    /// <summary>
    /// In memory repository to store user details.
    /// </summary>
    internal class UserListRepository : IUserRepository
    {
        private List<User> _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserListRepository"/> class.
        /// Initializes UserListRepository.
        /// </summary>
        public UserListRepository()
        {
            this._users = new List<User>();
        }

        /// <summary>
        /// Save users.
        /// </summary>
        /// <param name="users">users</param>
        public void SaveUsers(List<User> users)
        {
            this._users = users;
        }

        /// <summary>
        /// Loads users.
        /// </summary>
        /// <returns>list of users.</returns>
        public List<User> LoadUsers()
        {
            return this._users;
        }

        /// <summary>
        /// Adds users.
        /// </summary>
        /// <param name="user">user</param>
        public void AddUser(User user)
        {
            this._users.Add(user);
        }

        /// <summary>
        /// Deletes users.
        /// </summary>
        /// <param name="user">user</param>
        public void DeleteUser(User user)
        {
            this._users.Remove(user);
        }

        /// <summary>
        /// Update users.
        /// </summary>
        /// <param name="oldUser">oldUser</param>
        /// <param name="updatedUser">updatedUser</param>
        public void UpdateUser(User oldUser, User updatedUser)
        {
            oldUser.UserName = updatedUser.UserName;
        }
    }
}

using Assignment4.Models;

namespace Assignment4.Repository
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
        /// <param name="users">List of users.</param>
        public void SaveUsers(List<User> users)
        {
            this._users = users;
        }

        /// <summary>
        /// Loads users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<User> LoadUsers()
        {
            return this._users;
        }

        /// <summary>
        /// Adds users.
        /// </summary>
        /// <param name="user">Instance of user.</param>
        public void AddUser(User user)
        {
            this._users.Add(user);
        }

        /// <summary>
        /// Deletes users.
        /// </summary>
        /// <param name="user">Instance of user.</param>
        public void DeleteUser(User user)
        {
            this._users.Remove(user);
        }

        /// <summary>
        /// Update users.
        /// </summary>
        /// <param name="oldUser">oldUser instance.</param>
        /// <param name="updatedUser">updatedUser instance.</param>
        public void UpdateUser(User oldUser, User updatedUser)
        {
            oldUser.UserName = updatedUser.UserName;
        }
    }
}

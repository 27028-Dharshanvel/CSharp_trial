using System.Text.Json;
using Assignment5.Models;

namespace Assignment5.Repository
{
    /// <summary>
    /// User repository with persistence.
    /// </summary>
    internal class UserPersistenceRepository : IUserRepository
    {
        private readonly string _filePath = "users.json";

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">user</param>
        public void AddUser(User user)
        {
            var users = LoadUsers();
            users.Add(user);
            SaveUsers(users);
        }

        /// <summary>
        /// Deletes user
        /// </summary>
        /// <param name="user">user</param>
        public void DeleteUser(User user)
        {
            var users = LoadUsers();

            users.RemoveAll(u => u.UserId == user.UserId);

            this.SaveUsers(users);
        }

        /// <summary>
        /// Loads user
        /// </summary>
        /// <returns>list of users.</returns>
        public List<User> LoadUsers()
        {
            if (!File.Exists(_filePath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(json)
                   ?? new List<User>();
        }

        /// <summary>
        /// Saves users.
        /// </summary>
        /// <param name="users">list of users.</param>
        public void SaveUsers(List<User> users)
        {
            string json = JsonSerializer.Serialize(
                users,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="oldUser">oldUser</param>
        /// <param name="updatedUser">updatedUser</param>
        /// <exception cref="InvalidOperationException">InvalidOperationException.</exception>
        public void UpdateUser(User oldUser, User updatedUser)
        {
            var users = LoadUsers();

            int index = users.FindIndex(u => u.UserId == oldUser.UserId);

            if (index == -1)
            {
                throw new InvalidOperationException("User not found.");
            }

            users[index] = updatedUser;

            SaveUsers(users);
        }
    }
}
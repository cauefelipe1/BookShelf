namespace BookShelf.Data.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a <see cref="username"/> from the database based on the username.
        /// </summary>
        /// <param name="username">User's username.</param>
        /// <returns>Instance of <see cref="UserDao"/></returns>
        Task<UserDao?> GetUser(string username);

        /// <summary>
        /// Saves a <see cref="dao"/> into the database.
        /// </summary>
        /// <param name="dao">UserDTO with the user information.</param>
        /// <returns>User id generated during the insert.</returns>
        Task<Guid> SaveUser(UserDao dao);
    }
}

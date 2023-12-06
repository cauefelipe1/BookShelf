namespace BookShelf.Models
{
    /// <summary>
    /// Defines a model that represents a User Of the system
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// User's ID. This is the user unique identifier for the API.
        /// </summary>
        /// <example>979111bd-e576-4a94-b110-3bccfc23a72e</example>
        public Guid Id { get; set; }

        /// <summary>
        /// User's username. This is the user unique identifier for the biz.
        /// </summary>
        /// <example>admin</example>
        public string Username { get; set; }

        /// <summary>
        /// User's password.
        /// Only used to create a new user. When retrieving the user from the DB it will be masked.
        /// </summary>
        /// <example>*****</example>
        public string Password { get; set; }
    }
}

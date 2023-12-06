namespace BookShelf.Models.Authentication
{
    /// <summary>
    /// Defines all possible claims that a API user can has.
    /// </summary>
    public class IdentityClaimsModel
    {
        /// <summary>
        /// When the authenticated user is a device it represents the Device ID.
        /// Otherwise it represents the User ID.
        /// </summary>
        /// <example>1</example>
        public int UserId { get; set; }

        /// <summary>
        /// When the authenticated user is an user it represents the Username.
        /// </summary>
        /// <example>admin</example>
        public string Username { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        public IdentityClaimsModel() { }
    }
}

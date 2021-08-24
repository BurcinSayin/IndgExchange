namespace Exchange.Domain.User.Command
{
    /// <summary>
    /// Create User Command
    /// </summary>
    public class CreateUserCommand
    {
        /// <summary>
        /// User name to create
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
    }
}
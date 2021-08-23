namespace Exchange.Domain.User.Command
{
    /// <summary>
    /// Create Exchange User Command
    /// </summary>
    public class CreateUserCommand
    {
        /// <summary>
        /// User name to create
        /// </summary>
        public string UserName { get; set; }
    }
}
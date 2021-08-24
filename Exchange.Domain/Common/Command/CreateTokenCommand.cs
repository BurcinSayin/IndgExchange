namespace Exchange.Domain.Common.Command
{
    public class CreateTokenCommand
    {
        /// <summary>
        /// Name of user Case Sensitive
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Pass Case sensitive
        /// </summary>
        public string Password { get; set; }
    }
}

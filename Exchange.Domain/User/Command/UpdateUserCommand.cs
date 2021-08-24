namespace Exchange.Domain.User.Command
{
    public class UpdateUserCommand
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
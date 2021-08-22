namespace Exchange.Domain.ExchangeUser.Command
{
    public class UpdateExchangeUserCommand
    {
        public int ExchangeUserId { get; set; }
        public string Name { get; set; }
    }
}
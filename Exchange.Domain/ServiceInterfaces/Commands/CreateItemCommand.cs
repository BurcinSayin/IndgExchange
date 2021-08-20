namespace Exchange.Domain.ServiceInterfaces.Commands
{
    public class CreateItemCommand
    {
        public int? OwnerId { get; set; }
        public string ItemName { get; set; }
    }
}
namespace Exchange.Domain.ServiceInterfaces.Commands
{
    public class UpdateItemCommand
    {
        public int ItemId { get; set; }
        public int? HolderId { get; set; }
        public string ItemName { get; set; }
    }
}
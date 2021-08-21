namespace Exchange.Domain.Item.Command
{
    public class UpdateItemCommand
    {
        public int ItemId { get; set; }
        public int? HolderId { get; set; }
        public string ItemName { get; set; }
    }
}
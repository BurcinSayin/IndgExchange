namespace Exchange.Domain.Item.Command
{
    public class CreateItemCommand
    {
        /// <summary>
        /// User Id of owner
        /// </summary>
        public int? OwnerId { get; set; }
        /// <summary>
        /// Item Name
        /// </summary>
        public string ItemName { get; set; }
    }
}
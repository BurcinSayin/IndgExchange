namespace Exchange.Domain.Item.Command
{
    /// <summary>
    /// Update Item Command
    /// </summary>
    public class UpdateItemCommand
    {
        /// <summary>
        /// Target Item id
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// New Item Owner if any
        /// </summary>
        public int? HolderId { get; set; }
        /// <summary>
        /// New item name
        /// </summary>
        public string ItemName { get; set; }
    }
}
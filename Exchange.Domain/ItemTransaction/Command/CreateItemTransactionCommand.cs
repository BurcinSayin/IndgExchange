namespace Exchange.Domain.ItemTransaction.Command
{
    public class CreateItemTransactionCommand
    {
        /// <summary>
        /// Item whose owner is changing
        /// </summary>
        public int TakenItemId { get; set; }
        /// <summary>
        /// User who gives the taken item if any
        /// </summary>
        public int? GivingUserId { get; set; }
        /// <summary>
        /// Item given in exchange of Taken item
        /// </summary>
        public int? ExchangedItemId { get; set; }
        /// <summary>
        /// User who takes the item
        /// </summary>
        public int TakingUserId { get; set; }
    }
}
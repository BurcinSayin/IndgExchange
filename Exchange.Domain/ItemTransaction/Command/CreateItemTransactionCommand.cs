namespace Exchange.Domain.ItemTransaction.Command
{
    public class CreateItemTransactionCommand
    {
        public int TakenItemId { get; set; }
        public int? GivingUserId { get; set; }
        public int? ExchangedItemId { get; set; }
        public int TakingUserId { get; set; }
    }
}
namespace Exchange.Domain.ItemTransaction.Command
{
    public class CreateItemTransactionCommand
    {
        public int GivenItemId { get; set; }
        public int? GivingUserId { get; set; }
        public int? ExchangedItemId { get; set; }
        public int TakingUserId { get; set; }
    }
}
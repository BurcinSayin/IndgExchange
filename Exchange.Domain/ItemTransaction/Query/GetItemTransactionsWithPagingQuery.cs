namespace Exchange.Domain.ItemTransaction.Query
{
    public class GetItemTransactionsWithPagingQuery
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        
        public int? GivingUserId { get; set; }
        public int? TakingUserId { get; set; }
        public int? GivenItemId { get; set; }
        public int? ExchangedItemId { get; set; }
    }
}
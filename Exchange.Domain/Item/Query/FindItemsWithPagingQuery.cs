namespace Exchange.Domain.Item.Query
{
    public class FindItemsWithPagingQuery
    {
        public string ItemName { get; set; }
        public int? OwnerId { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
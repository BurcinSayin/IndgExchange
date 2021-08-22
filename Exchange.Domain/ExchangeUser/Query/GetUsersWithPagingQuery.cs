namespace Exchange.Domain.ExchangeUser.Query
{
    public class GetUsersWithPagingQuery
    {
        public string UserName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
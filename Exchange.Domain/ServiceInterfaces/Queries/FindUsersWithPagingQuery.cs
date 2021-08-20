namespace Exchange.Domain.ServiceInterfaces.Queries
{
    public class FindUsersWithPagingQuery
    {
        public string UserName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
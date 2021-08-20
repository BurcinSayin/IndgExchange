namespace Exchange.Domain.DataInterfaces
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        
        public ExchangeUser Holder { get; set; }
    }
}
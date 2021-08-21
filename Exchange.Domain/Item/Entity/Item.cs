namespace Exchange.Domain.Item.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        
        public ExchangeUser.Entity.ExchangeUser Holder { get; set; }
    }
}
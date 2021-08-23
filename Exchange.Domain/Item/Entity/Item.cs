using Exchange.Domain.User.Entity;

namespace Exchange.Domain.Item.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        
        public User.Entity.User Holder { get; set; }
    }
}
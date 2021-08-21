using System.Collections.Generic;

namespace Exchange.Domain.ExchangeUser.Entity
{
    public class ExchangeUser
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        
        public List<Item.Entity.Item> ItemList { get; set; }

    }
}
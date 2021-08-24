using System.Collections.Generic;

namespace Exchange.Domain.User.Entity
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        
        
        public List<Item.Entity.Item> Items { get; set; }

    }
}
﻿using System.Collections.Generic;

namespace Exchange.Domain.DataInterfaces
{
    public class Owner
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        
        public List<Item> ItemList { get; set; }

    }
}
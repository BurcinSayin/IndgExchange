using System;

namespace Exchange.Domain.ItemTransaction.Entity
{
    public class ItemTransaction
    {
        public int Id { get; set; }
        
        public int? GivingUserId { get; set; }
        public int TakenItemId { get; set; }
        public int TakingUserId { get; set; }
        public int? ExchangedItemId { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
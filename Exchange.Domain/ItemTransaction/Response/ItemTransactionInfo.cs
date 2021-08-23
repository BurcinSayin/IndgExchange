using Exchange.Domain.Item.Response;

namespace Exchange.Domain.ItemTransaction.Response
{
    public class ItemTransactionInfo
    {
        public int GivenItemId  { get; set; }
        public int GivingUserId { get; set; }
        public int ExchangedItemId { get; set; }
        public int TakingUserId { get; set; }
        public int Id { get; set; }


        public static ItemTransactionInfo MapToInfo(Entity.ItemTransaction toMap)
        {
            if (toMap == null)
            {
                return null;
            }

            return new ItemTransactionInfo()
            {
                Id = toMap.Id,
                GivenItemId = toMap.GivenItemId,
                GivingUserId = toMap.GivingUserId.GetValueOrDefault(0) ,
                ExchangedItemId = toMap.ExchangedItemId.GetValueOrDefault(0),
                TakingUserId = toMap.TakingUserId
            };
        }
    }
}
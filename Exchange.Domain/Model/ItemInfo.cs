using Exchange.Domain.DataInterfaces;

namespace Exchange.Domain.Model
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        
        public string Owner { get; set; }


        public static ItemInfo MapToInfo(Item toMap)
        {
            return new ItemInfo()
            {
                Id = toMap.Id,
                ItemName = toMap.ItemName,
                Owner = toMap.Holder != null ? toMap.Holder.Name : null
            };
        }
    }
}
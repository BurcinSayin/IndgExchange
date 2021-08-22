namespace Exchange.Domain.Item.Response
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        
        public string Owner { get; set; }


        public static ItemInfo MapToInfo(Entity.Item toMap)
        {
            if (toMap == null)
            {
                return null;
            }
            return new ItemInfo()
            {
                Id = toMap.Id,
                ItemName = toMap.ItemName,
                Owner = toMap.Holder != null ? toMap.Holder.Name : null
            };
        }
    }
}
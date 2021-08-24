namespace Exchange.Domain.Item.Response
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        
        public string Owner { get; set; }
        public int? OwnerId { get; set; }


        public static ItemInfo MapToInfo(Entity.Item toMap)
        {
            if (toMap == null)
            {
                return null;
            }
            var retVal = new ItemInfo()
            {
                Id = toMap.Id,
                ItemName = toMap.ItemName,
            };
            if (toMap.User != null)
            {
                retVal.Owner = toMap.User.Name;
                retVal.OwnerId = toMap.User.Id;
            }
            else
            {
                retVal.Owner = null;
                retVal.OwnerId = null;
            }

            return retVal;
        }
    }
}
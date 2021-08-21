using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Response;

namespace Exchange.Domain.Item.Service
{
    public interface IItemWriteService
    {
        ItemInfo CreateItem(CreateItemCommand createCommand);
        ItemInfo UpdateItem(UpdateItemCommand command);
        void DeleteItem(DeleteItemCommand command);
    }
}
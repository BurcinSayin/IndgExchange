using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.ServiceInterfaces
{
    public interface IItemWriteService
    {
        ItemInfo CreateItem(CreateItemCommand createCommand);
    }
}
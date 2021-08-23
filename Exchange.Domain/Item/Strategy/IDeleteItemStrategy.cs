using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Domain.Item.Strategy
{
    public interface IDeleteItemStrategy
    {
        bool Delete(IItemRepository itemRepository, IUserRepository userRepository,DeleteItemCommand command);
    }

}
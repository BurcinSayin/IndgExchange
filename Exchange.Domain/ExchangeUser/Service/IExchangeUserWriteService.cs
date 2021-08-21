using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Response;

namespace Exchange.Domain.ExchangeUser.Service
{
    public interface IExchangeUserWriteService
    {
        ExchangeUserInfo CreateExchangeUser(CreateExchangeUserCommand command);
        ExchangeUserInfo UpdateExchangeUser(UpdateExchangeUserCommand command);
        void DeleteExchangeUser(DeleteExchangeUserCommand command);
    }
}
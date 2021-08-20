using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Services
{
    public class ExchangeUserWriteService:IExchangeUserWriteService
    {
        private IExchangeUserRepository _exchangeUserRepository;

        public ExchangeUserWriteService(IExchangeUserRepository exchangeUserRepository)
        {
            _exchangeUserRepository = exchangeUserRepository;
        }


        public ExchangeUserInfo CreateExchangeUser(CreateExchangeUserCommand command)
        {
            var toCreate = new ExchangeUser()
            {
                Name = command.UserName
            };

            return _exchangeUserRepository.Add(toCreate).ToExchangeUserInfo();
        }
    }
}
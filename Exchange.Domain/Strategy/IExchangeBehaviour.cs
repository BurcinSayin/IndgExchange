
namespace Exchange.Domain.Strategy
{
    public interface IExchangeBehaviour
    {
        public void ExecuteCommand(IBehaviourCommand command);
    }

}
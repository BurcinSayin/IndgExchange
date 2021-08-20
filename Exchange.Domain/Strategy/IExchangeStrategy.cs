namespace Exchange.Domain.Strategy
{
    public interface IExchangeStrategy
    {
        void AddBehaviour(IExchangeBehaviour toAdd);

        void HandleCommand(IBehaviourCommand command);
    }
}
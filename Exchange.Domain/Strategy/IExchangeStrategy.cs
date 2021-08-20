namespace Exchange.Domain.Strategy
{
    public interface IExchangeStrategy
    {
        void AddBehaviour(IExchangeBehaviour toAdd);
    }
}
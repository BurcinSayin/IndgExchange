using Exchange.Domain;
using Exchange.Domain.DataInterfaces;

namespace Exchange.Data.Sqlite
{
    public class SqliteUnitOfWork:IUnitOfWork
    {
        public IItemRepository Items { get; }
        public IOwnerRepository Owners { get; }
        
        private readonly ExchangeDataContext _context;


        public SqliteUnitOfWork(ExchangeDataContext context, IItemRepository itemRepository,IOwnerRepository ownerRepository)
        {
            _context = context;
            Items = itemRepository;
            Owners = ownerRepository;

            _context.Database.CreateExecutionStrategy();
            _context.Database.AutoTransactionsEnabled = true;
        }

        public void Register(object trg)
        {
            _context.Update(trg);
        }
        
        public int CommitChanges()
        {
            return _context.SaveChanges(false);
        }

        public void Dispose()
        {
            
            _context?.Dispose();
        }
    }
}
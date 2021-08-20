using System;
using Exchange.Domain.DataInterfaces;

namespace Exchange.Domain
{
    public interface IUnitOfWork:IDisposable
    {
        IItemRepository Items { get; }
        IOwnerRepository Owners { get; }
        int CommitChanges();
    }
}
using System;

namespace Exchange.Domain.DataInterfaces
{
    public interface IDataTransaction
    {
        void Commit();
        void Rollback();
    }
}
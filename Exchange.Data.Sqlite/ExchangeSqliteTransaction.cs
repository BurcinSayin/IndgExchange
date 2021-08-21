using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Domain.DataInterfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Exchange.Data.Sqlite
{
    public class ExchangeSqliteTransaction:IDataTransaction
    {
        private IDbContextTransaction _dbContextTransaction;

        public ExchangeSqliteTransaction(IDbContextTransaction dbContextTransaction)
        {
            _dbContextTransaction = dbContextTransaction;
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction.Rollback();
        }
    }
}

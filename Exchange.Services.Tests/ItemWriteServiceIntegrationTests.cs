using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Data.Sqlite;
using NUnit.Framework;

namespace Exchange.Services.Tests
{
    class ItemWriteServiceIntegrationTests
    {
        private ItemWriteService testService;


        [OneTimeSetUp]
        public void InitDb()
        {
            ExchangeDataContext testDbContext = new ExchangeDataContext();
            testService = new ItemWriteService(new ItemRepository(testDbContext) ,new ExchangeUserRepository(testDbContext));
        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Data.Sqlite;
using Exchange.Domain.Item.Command;
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


        [Test]
        public void CreateItem_ItemWithoutOwner_Success()
        {
            var command = new CreateItemCommand()
            {
                ItemName = "TestItesm"
            };
            var res = testService.CreateItem(command);
            
            Assert.Greater(res.Id,0);
        }
        
        
        [Test]
        public void CreateItem_WithOwner_Fail()
        {
            var command = new CreateItemCommand()
            {
                ItemName = "TestItesm",
                OwnerId = 1
            };
            var res = testService.CreateItem(command);
            
            Assert.Greater(res.Id,0);
        }

    }
}

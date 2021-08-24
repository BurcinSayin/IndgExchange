using Exchange.Core.Item.Service;
using Exchange.Core.Item.Strategy;
using Exchange.Data.Sqlite;
using Exchange.Domain.Item.Command;
using NUnit.Framework;

namespace Exchange.Core.Tests.Item.Service
{
    class ItemWriteServiceIntegrationTests
    {
        private ItemWriteService testService;


        [OneTimeSetUp]
        public void InitDb()
        {
            ItemWriteStrategySet strategySet = new ItemWriteStrategySet(
                new CreateItemWithTransaction(),
                new UpdateItemWithTransaction(),
                new DeleteItemSimple()
            );
            ExchangeDataContext testDbContext = new ExchangeDataContext();
            testService = new ItemWriteService(strategySet,new ItemRepository(testDbContext) ,
                new UserRepository(testDbContext),new ItemTransactionRepository(testDbContext));
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
        public void CreateItem_WithOwner_Success()
        {
            var command = new CreateItemCommand()
            {
                ItemName = "TestItesm",
                OwnerId = 1
            };
            var res = testService.CreateItem(command);
            
            Assert.Greater(res.Id,0);
        }
        
        [Test]
        public void UdateItem_WithOwner_Success()
        {
            var command = new CreateItemCommand()
            {
                ItemName = "TestItesm",
            };
            var createResponse = testService.CreateItem(command);

            var updateResponse = testService.UpdateItem(new UpdateItemCommand()
            {
                HolderId = 1,
                ItemId = createResponse.Id,
                ItemName = "After Update"
            });
            
            Assert.Greater(updateResponse.Id,0);
        }

    }
}

using Exchange.Data.Sqlite;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.DataInterfaces;

namespace Exchange.Data.Sqlite.Tests
{
    [TestFixture]
    public class ItemRepositoryTests
    {
        private ExchangeDataContext testDataContext;


        [OneTimeSetUp]
        public void InitTestDb()
        {
            testDataContext = new ExchangeDataContext();

            // testDataContext.ExchangeUsers.Add(new Owner());
        }
        
        
        // [SetUp]
        // public void SetUp()
        // {
        // }

        private ItemRepository CreateItemRepository()
        {
            return new ItemRepository(testDataContext);
        }

       
        [Test]
        public void MoveItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var itemRepository = this.CreateItemRepository();
            int fromId = 1;
            int toId = 2;
            int itemId = 1;

            // Act
            var result = itemRepository.MoveItem(
                fromId,
                toId,
                itemId);

            // Assert
            Assert.Pass();
        }
    }
}

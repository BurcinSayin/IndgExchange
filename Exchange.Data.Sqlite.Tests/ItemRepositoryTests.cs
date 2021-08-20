using Exchange.Data.Sqlite;
using Moq;
using NUnit.Framework;
using System;

namespace Exchange.Data.Sqlite.Tests
{
    [TestFixture]
    public class ItemRepositoryTests
    {
        private ExchangeDataContext testDataContext;

        [SetUp]
        public void SetUp()
        {

            testDataContext = new ExchangeDataContext();
        }

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

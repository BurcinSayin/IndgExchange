using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Core.Item.Service;
using Exchange.Domain.Item.Query;

namespace Exchange.Services.Tests
{
    [TestFixture]
    public class ItemReadServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockItemRepository = this.mockRepository.Create<IItemRepository>();
        }

        private ItemReadService CreateService()
        {
            return new ItemReadService(
                this.mockItemRepository.Object);
        }

        [Test]
        public void GetItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            GetItemQuery query = new GetItemQuery();

            // Act
            var result = service.GetItem(query);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void GetItems_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            GetItemsWithPagingQuery query = null;

            // Act
            var result = service.GetItems(
                query);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

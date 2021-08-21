using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Core.Item.Service;
using Exchange.Domain.Item.Command;

namespace Exchange.Services.Tests
{
    [TestFixture]
    public class ItemWriteServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IExchangeUserRepository> mockExchangeUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockItemRepository = this.mockRepository.Create<IItemRepository>();
            this.mockExchangeUserRepository = this.mockRepository.Create<IExchangeUserRepository>();
        }

        private ItemWriteService CreateService()
        {
            return new ItemWriteService(
                this.mockItemRepository.Object,
                this.mockExchangeUserRepository.Object);
        }

        [Test]
        public void CreateItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            CreateItemCommand createCommand = null;

            // Act
            var result = service.CreateItem(
                createCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

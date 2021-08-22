using Exchange.Core.Item.Service;
using Exchange.Domain.DataInterfaces;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Tests.Item.Service
{
    [TestFixture]
    public class ItemWriteServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IExchangeUserRepository> mockExchangeUserRepository;
        
        private Mock<ICreateItemStrategy> mockCreateStrategy;
        private Mock<IUpdateItemStrategy> mockUpdateStratgy;
        private Mock<IDeleteItemStrategy> mockDeleteStrategy;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockItemRepository = this.mockRepository.Create<IItemRepository>();
            this.mockExchangeUserRepository = this.mockRepository.Create<IExchangeUserRepository>();
            mockCreateStrategy = mockRepository.Create<ICreateItemStrategy>();
            mockUpdateStratgy = mockRepository.Create<IUpdateItemStrategy>();
            mockDeleteStrategy = mockRepository.Create<IDeleteItemStrategy>();
        }

        private ItemWriteService CreateService()
        {
            ItemWriteStrategySet strategySet = new ItemWriteStrategySet(
                mockCreateStrategy.Object,
                mockUpdateStratgy.Object,
                mockDeleteStrategy.Object
                );
            return new ItemWriteService(
                strategySet,
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

        [Test]
        public void UpdateItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            UpdateItemCommand command = null;

            // Act
            var result = service.UpdateItem(
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void DeleteItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            DeleteItemCommand command = null;

            // Act
            service.DeleteItem(
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

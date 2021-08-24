using System;
using Exchange.Core.Item.Service;
using Exchange.Core.ItemTransaction.Service;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;
using Exchange.Domain.ItemTransaction.Command;
using Exchange.Domain.ItemTransaction.Strategy;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.ItemTransaction.Service
{
    [TestFixture]
    public class ItemTransactionWriteServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IUserRepository> mockUserRepository;
        private Mock<IItemTransactionRepository> mockItemTtansactionRepository;
        
        private Mock<ICreateItemTransactionStrategy> mockCreateStrategy;


        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockUserRepository = mockRepository.Create<IUserRepository>();
            mockItemTtansactionRepository = mockRepository.Create<IItemTransactionRepository>();

            mockCreateStrategy = mockRepository.Create<ICreateItemTransactionStrategy>();

        }
        
        private ItemTransactionWriteService CreateService()
        {
            return new ItemTransactionWriteService(
                mockCreateStrategy.Object,
                this.mockItemRepository.Object,
                this.mockUserRepository.Object,
                mockItemTtansactionRepository.Object);
        }

        [Test]
        public void CreateItemTransaction_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            CreateItemTransactionCommand createCommand = new CreateItemTransactionCommand()
            {
                TakenItemId = 42,
                TakingUserId = 42
            };
            mockCreateStrategy.Setup(stategy => stategy.Create(It.IsAny<IItemRepository>(),
                It.IsAny<IUserRepository>(), It.IsAny<IItemTransactionRepository>(),
                It.IsAny<CreateItemTransactionCommand>())).Returns(new Domain.ItemTransaction.Entity.ItemTransaction());

            // Act
            var result = service.CreateItemTransaction(createCommand);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void CreateItemTransaction_InvalidCommand_Success()
        {
            // Arrange
            var service = this.CreateService();
            CreateItemTransactionCommand createCommand = new CreateItemTransactionCommand()
            {
                TakenItemId = 42,
                TakingUserId = 42,
                ExchangedItemId = -1
            };

            var ex = Assert.Throws<ValidationException>(() =>
            {
                service.CreateItemTransaction(createCommand);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }
    }
}
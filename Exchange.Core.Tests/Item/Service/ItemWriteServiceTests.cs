using Exchange.Core.Item.Service;
using Exchange.Domain.DataInterfaces;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;
using FluentValidation;

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
        public void CreateItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            CreateItemCommand createCommand = new CreateItemCommand()
            {
                ItemName = "test"
            };
            mockCreateStrategy.Setup(stategy => stategy.Create(It.IsAny<IItemRepository>(),
                It.IsAny<IExchangeUserRepository>(),
                It.IsAny<CreateItemCommand>())).Returns(new Domain.Item.Entity.Item());

            // Act
            var result = service.CreateItem(createCommand);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void CreateItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            CreateItemCommand createCommand = new CreateItemCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.CreateItem(createCommand);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            UpdateItemCommand command = new UpdateItemCommand()
            {
                ItemId = 42,
                ItemName = "Test"
            };
            mockUpdateStratgy.Setup(stategy => stategy.Update(It.IsAny<IItemRepository>(),
                It.IsAny<IExchangeUserRepository>(),
                It.IsAny<UpdateItemCommand>())).Returns(new Domain.Item.Entity.Item());

            // Act
            var result = service.UpdateItem(command);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void UpdateItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            UpdateItemCommand command = new UpdateItemCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.UpdateItem(command);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }

        [Test]
        public void DeleteItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            DeleteItemCommand command = new DeleteItemCommand()
            {
                ItemId = 42
            };
            mockDeleteStrategy.Setup(stategy => stategy.Delete(It.IsAny<IItemRepository>(),
                It.IsAny<IExchangeUserRepository>(),
                It.IsAny<DeleteItemCommand>())).Returns(true);

            // Act
            service.DeleteItem(command);

            // Assert
            Assert.Pass("Delete completed successfully");
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void DeleteItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            DeleteItemCommand command = new DeleteItemCommand()
            {
                ItemId = -1
            };

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.DeleteItem(command);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }
    }
}

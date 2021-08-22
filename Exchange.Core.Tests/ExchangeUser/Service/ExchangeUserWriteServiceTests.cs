using Exchange.Core.ExchangeUser.Service;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Strategy;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.ExchangeUser.Service
{
    [TestFixture]
    public class ExchangeUserWriteServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IExchangeUserRepository> mockExchangeUserRepository;
        private Mock<ICreateExchangeUserStategy> mockCreateStrategy;
        private Mock<IUpdateExchangeUserStrategy> mockUpdateStratgy;
        private Mock<IDeleteExchangeUserStrategy> mockDeleteStrategy;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockItemRepository = this.mockRepository.Create<IItemRepository>();
            this.mockExchangeUserRepository = this.mockRepository.Create<IExchangeUserRepository>();
            mockCreateStrategy = mockRepository.Create<ICreateExchangeUserStategy>();
            mockUpdateStratgy = mockRepository.Create<IUpdateExchangeUserStrategy>();
            mockDeleteStrategy = mockRepository.Create<IDeleteExchangeUserStrategy>();
        }

        private ExchangeUserWriteService CreateService()
        {
            ExchangeUserWriteStrategySet strategySet = new ExchangeUserWriteStrategySet(
                mockCreateStrategy.Object,
                mockUpdateStratgy.Object,
                mockDeleteStrategy.Object);
            return new ExchangeUserWriteService( strategySet ,this.mockItemRepository.Object,
                this.mockExchangeUserRepository.Object);
        }

        [Test]
        public void CreateItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            CreateExchangeUserCommand createCommand = new CreateExchangeUserCommand()
            {
                UserName = "TestUSer"
            };
            mockCreateStrategy.Setup(stategy => stategy.Create(It.IsAny<IItemRepository>(),
                It.IsAny<IExchangeUserRepository>(),
                It.IsAny<CreateExchangeUserCommand>())).Returns(new Domain.ExchangeUser.Entity.ExchangeUser());
                

            // Act
            var result = service.CreateExchangeUser(createCommand);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void CreateItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            CreateExchangeUserCommand createCommand = new CreateExchangeUserCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.CreateExchangeUser(createCommand);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            UpdateExchangeUserCommand command = new UpdateExchangeUserCommand()
            {
                ExchangeUserId = 42
            };
            mockUpdateStratgy.Setup(stategy => stategy.Update(It.IsAny<IItemRepository>(),
                It.IsAny<IExchangeUserRepository>(),
                It.IsAny<UpdateExchangeUserCommand>())).Returns(new Domain.ExchangeUser.Entity.ExchangeUser());

            // Act
            var result = service.UpdateExchangeUser(command);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void UpdateItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            UpdateExchangeUserCommand command = new UpdateExchangeUserCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.UpdateExchangeUser(command);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void DeleteItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            DeleteExchangeUserCommand command = new DeleteExchangeUserCommand()
            {
                ExchangeUserId = 42
            };
            mockDeleteStrategy.Setup(stategy => stategy.Delete(It.IsAny<IItemRepository>(),
                It.IsAny<IExchangeUserRepository>(),
                It.IsAny<DeleteExchangeUserCommand>())).Returns(true);

            // Act
            service.DeleteExchangeUser(command);

            // Assert
            Assert.Pass("Delete Completed Successfully.");
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void DeleteItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            DeleteExchangeUserCommand command = new DeleteExchangeUserCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.DeleteExchangeUser(command);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }
        
       
    }
}

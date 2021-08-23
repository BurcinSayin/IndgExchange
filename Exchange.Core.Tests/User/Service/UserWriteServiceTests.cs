using Exchange.Core.User.Service;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Strategy;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.User.Service
{
    [TestFixture]
    public class UserWriteServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IUserRepository> mockUserRepository;
        private Mock<ICreateUserStrategy> mockCreateStrategy;
        private Mock<IUpdateUserStrategy> mockUpdateStratgy;
        private Mock<IDeleteUserStrategy> mockDeleteStrategy;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockItemRepository = this.mockRepository.Create<IItemRepository>();
            this.mockUserRepository = this.mockRepository.Create<IUserRepository>();
            mockCreateStrategy = mockRepository.Create<ICreateUserStrategy>();
            mockUpdateStratgy = mockRepository.Create<IUpdateUserStrategy>();
            mockDeleteStrategy = mockRepository.Create<IDeleteUserStrategy>();
        }

        private UserWriteService CreateService()
        {
            UserWriteStrategySet strategySet = new UserWriteStrategySet(
                mockCreateStrategy.Object,
                mockUpdateStratgy.Object,
                mockDeleteStrategy.Object);
            return new UserWriteService( strategySet ,this.mockItemRepository.Object,
                this.mockUserRepository.Object);
        }

        [Test]
        public void CreateItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            CreateUserCommand createCommand = new CreateUserCommand()
            {
                UserName = "TestUSer"
            };
            mockCreateStrategy.Setup(stategy => stategy.Create(It.IsAny<IItemRepository>(),
                It.IsAny<IUserRepository>(),
                It.IsAny<CreateUserCommand>())).Returns(new Domain.User.Entity.User());
                

            // Act
            var result = service.CreateUser(createCommand);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void CreateItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            CreateUserCommand createCommand = new CreateUserCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.CreateUser(createCommand);
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
            UpdateUserCommand command = new UpdateUserCommand()
            {
                UserId = 42
            };
            mockUpdateStratgy.Setup(stategy => stategy.Update(It.IsAny<IItemRepository>(),
                It.IsAny<IUserRepository>(),
                It.IsAny<UpdateUserCommand>())).Returns(new Domain.User.Entity.User());

            // Act
            var result = service.UpdateUser(command);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void UpdateItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            UpdateUserCommand command = new UpdateUserCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.UpdateUser(command);
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
            DeleteUserCommand command = new DeleteUserCommand()
            {
                UserId = 42
            };
            mockDeleteStrategy.Setup(stategy => stategy.Delete(It.IsAny<IItemRepository>(),
                It.IsAny<IUserRepository>(),
                It.IsAny<DeleteUserCommand>())).Returns(true);

            // Act
            service.DeleteUser(command);

            // Assert
            Assert.Pass("Delete Completed Successfully.");
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void DeleteItem_InvalidCommand_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            DeleteUserCommand command = new DeleteUserCommand();

            // Act
            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.DeleteUser(command);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }
        
       
    }
}

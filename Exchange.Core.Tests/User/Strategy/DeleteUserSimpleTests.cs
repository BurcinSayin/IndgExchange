using Exchange.Core.Shared;
using Exchange.Core.User.Strategy;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.User.Strategy
{
    [TestFixture]
    public class DeleteUserSimpleTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IUserRepository> mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockUserRepository = mockRepository.Create<IUserRepository>();
        }

        private DeleteUserSimple CreateDeleteUserSimple()
        {
            return new DeleteUserSimple();
        }

        [Test]
        public void Delete_AllOk_Success()
        {
            // Arrange
            var deleteUserSimple = this.CreateDeleteUserSimple();
            DeleteUserCommand command = new DeleteUserCommand()
            {
                UserId = 42
            };
            mockUserRepository.Setup(ur => ur.Delete(It.IsAny<int>()))
                .Returns(true);

            // Act
            var result = deleteUserSimple.Delete(
                mockItemRepository.Object,
                mockUserRepository.Object,
                command);

            // Assert
            Assert.IsTrue(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void Delete_NotExistItem_ThrowNotFound()
        {
            // Arrange
            var deleteUserSimple = this.CreateDeleteUserSimple();
            DeleteUserCommand command = new DeleteUserCommand()
            {
                UserId = 42
            };
            mockUserRepository.Setup(ur => ur.Delete(It.IsAny<int>()))
                .Returns(false);

            var ex = Assert.Throws<NotFoundException>(() =>
            {
                deleteUserSimple.Delete(
                    mockItemRepository.Object,
                    mockUserRepository.Object,
                    command);
            });

            // Assert
            Assert.IsInstanceOf<NotFoundException>(ex);
            this.mockRepository.VerifyAll();
        }
    }
}

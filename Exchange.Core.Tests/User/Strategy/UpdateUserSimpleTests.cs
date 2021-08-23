using Exchange.Core.Shared;
using Exchange.Core.User.Strategy;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.User.Strategy
{
    [TestFixture]
    public class UpdateUserSimpleTests
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

        private UpdateUserSimple CreateUpdateUserSimple()
        {
            return new UpdateUserSimple();
        }

        [Test]
        public void Update_AllOk_Success()
        {
            // Arrange
            var updateUserSimple = this.CreateUpdateUserSimple();
            UpdateUserCommand command = new UpdateUserCommand()
            {
                UserId = 42,
                Name = "TestUSer"
            };
            mockUserRepository.Setup(ur => ur.Get(It.IsAny<int>()))
                .Returns(new Domain.User.Entity.User() { Id = command.UserId });
            Domain.User.Entity.User updatedUser = null;
            mockUserRepository.Setup(ur => ur.Update(It.IsAny<Domain.User.Entity.User>()))
                .Returns(new Domain.User.Entity.User())
                .Callback<Domain.User.Entity.User>(user => updatedUser = user);

            var result = updateUserSimple.Update(
                mockItemRepository.Object,
                mockUserRepository.Object,
                command);

            Assert.AreEqual(command.UserId,updatedUser.Id);
            Assert.AreEqual(command.Name,updatedUser.Name);
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Update_NotExistItem_ThrowNotFount()
        {
            var updateUserSimple = this.CreateUpdateUserSimple();
            UpdateUserCommand command = new UpdateUserCommand()
            {
                UserId = 42,
                Name = "TestUSer"
            };
            mockUserRepository.Setup(ur => ur.Get(It.IsAny<int>()))
                .Returns(() => null);
            
            var ex = Assert.Throws<NotFoundException>(() =>
            {
                updateUserSimple.Update(
                    mockItemRepository.Object,
                    mockUserRepository.Object,
                    command);
            });
            


            Assert.IsInstanceOf<NotFoundException>(ex);
            this.mockRepository.VerifyAll();
        }
    }
}

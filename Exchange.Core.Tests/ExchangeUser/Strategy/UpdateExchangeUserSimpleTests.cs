using Exchange.Core.ExchangeUser.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Core.Tests.ExchangeUser.Strategy
{
    [TestFixture]
    public class UpdateExchangeUserSimpleTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IExchangeUserRepository> mockExchangeUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockExchangeUserRepository = mockRepository.Create<IExchangeUserRepository>();
        }

        private UpdateExchangeUserSimple CreateUpdateExchangeUserSimple()
        {
            return new UpdateExchangeUserSimple();
        }

        [Test]
        public void Update_AllOk_Success()
        {
            // Arrange
            var updateExchangeUserSimple = this.CreateUpdateExchangeUserSimple();
            UpdateExchangeUserCommand command = new UpdateExchangeUserCommand()
            {
                ExchangeUserId = 42,
                Name = "TestUSer"
            };
            mockExchangeUserRepository.Setup(ur => ur.Get(It.IsAny<int>()))
                .Returns(new Domain.ExchangeUser.Entity.ExchangeUser() { Id = command.ExchangeUserId });
            Domain.ExchangeUser.Entity.ExchangeUser updatedUser = null;
            mockExchangeUserRepository.Setup(ur => ur.Update(It.IsAny<Domain.ExchangeUser.Entity.ExchangeUser>()))
                .Returns(new Domain.ExchangeUser.Entity.ExchangeUser())
                .Callback<Domain.ExchangeUser.Entity.ExchangeUser>(user => updatedUser = user);

            var result = updateExchangeUserSimple.Update(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            Assert.AreEqual(command.ExchangeUserId,updatedUser.Id);
            Assert.AreEqual(command.Name,updatedUser.Name);
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Update_NotExistItem_ThrowNotFount()
        {
            var updateExchangeUserSimple = this.CreateUpdateExchangeUserSimple();
            UpdateExchangeUserCommand command = new UpdateExchangeUserCommand()
            {
                ExchangeUserId = 42,
                Name = "TestUSer"
            };
            mockExchangeUserRepository.Setup(ur => ur.Get(It.IsAny<int>()))
                .Returns(() => null);
            
            var ex = Assert.Throws<NotFoundException>(() =>
            {
                updateExchangeUserSimple.Update(
                    mockItemRepository.Object,
                    mockExchangeUserRepository.Object,
                    command);
            });
            


            Assert.IsInstanceOf<NotFoundException>(ex);
            this.mockRepository.VerifyAll();
        }
    }
}

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
    public class DeleteExchangeUserSimpleTests
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

        private DeleteExchangeUserSimple CreateDeleteExchangeUserSimple()
        {
            return new DeleteExchangeUserSimple();
        }

        [Test]
        public void Delete_AllOk_Success()
        {
            // Arrange
            var deleteExchangeUserSimple = this.CreateDeleteExchangeUserSimple();
            DeleteExchangeUserCommand command = new DeleteExchangeUserCommand()
            {
                ExchangeUserId = 42
            };
            mockExchangeUserRepository.Setup(ur => ur.Delete(It.IsAny<int>()))
                .Returns(true);

            // Act
            var result = deleteExchangeUserSimple.Delete(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            // Assert
            Assert.IsTrue(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void Delete_NotExistItem_ThrowNotFound()
        {
            // Arrange
            var deleteExchangeUserSimple = this.CreateDeleteExchangeUserSimple();
            DeleteExchangeUserCommand command = new DeleteExchangeUserCommand()
            {
                ExchangeUserId = 42
            };
            mockExchangeUserRepository.Setup(ur => ur.Delete(It.IsAny<int>()))
                .Returns(false);

            var ex = Assert.Throws<NotFoundException>(() =>
            {
                deleteExchangeUserSimple.Delete(
                    mockItemRepository.Object,
                    mockExchangeUserRepository.Object,
                    command);
            });

            // Assert
            Assert.IsInstanceOf<NotFoundException>(ex);
            this.mockRepository.VerifyAll();
        }
    }
}

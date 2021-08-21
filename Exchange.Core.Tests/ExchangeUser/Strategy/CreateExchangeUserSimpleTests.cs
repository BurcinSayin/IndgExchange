using Exchange.Core.ExchangeUser.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Core.Tests.ExchangeUser.Strategy
{
    [TestFixture]
    public class CreateExchangeUserSimpleTests
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

        private CreateExchangeUserSimple CreateCreateExchangeUserSimple()
        {
            return new CreateExchangeUserSimple();
        }

        [Test]
        public void Create_NullCommand_ValidationException()
        {
            // Arrange
            var createExchangeUserSimple = this.CreateCreateExchangeUserSimple();
            CreateExchangeUserCommand command = null;

            // Act
            var result = createExchangeUserSimple.Create(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Create_EmptyUserName_ValidationException()
        {
            var createExchangeUserSimple = this.CreateCreateExchangeUserSimple();
            CreateExchangeUserCommand command = null;

            var result = createExchangeUserSimple.Create(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

using Exchange.Core.ExchangeUser.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Core.Tests.ExchangeUser.Strategy
{
    [TestFixture]
    public class UpdateExchangeUserSimpleTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private UpdateExchangeUserSimple CreateUpdateExchangeUserSimple()
        {
            return new UpdateExchangeUserSimple();
        }

        [Test]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var updateExchangeUserSimple = this.CreateUpdateExchangeUserSimple();
            IItemRepository itemRepository = null;
            IExchangeUserRepository exchangeUserRepository = null;
            UpdateExchangeUserCommand command = null;

            // Act
            var result = updateExchangeUserSimple.Update(
                itemRepository,
                exchangeUserRepository,
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

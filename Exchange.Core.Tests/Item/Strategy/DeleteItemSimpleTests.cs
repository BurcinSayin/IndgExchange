using Exchange.Core.Item.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Core.Tests.Item.Strategy
{
    [TestFixture]
    public class DeleteItemSimpleTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private DeleteItemSimple CreateDeleteItemSimple()
        {
            return new DeleteItemSimple();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var deleteItemSimple = this.CreateDeleteItemSimple();
            IItemRepository itemRepository = null;
            IExchangeUserRepository exchangeUserRepository = null;
            DeleteItemCommand command = null;

            // Act
            var result = deleteItemSimple.Delete(
                itemRepository,
                exchangeUserRepository,
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

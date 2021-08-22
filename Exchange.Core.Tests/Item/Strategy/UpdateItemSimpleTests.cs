using Exchange.Core.Item.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Core.Tests.Item.Strategy
{
    [TestFixture]
    public class UpdateItemSimpleTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private UpdateItemSimple CreateUpdateItemSimple()
        {
            return new UpdateItemSimple();
        }

        [Test]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var updateItemSimple = this.CreateUpdateItemSimple();
            IItemRepository itemRepository = null;
            IExchangeUserRepository exchangeUserRepository = null;
            UpdateItemCommand command = null;

            // Act
            var result = updateItemSimple.Update(
                itemRepository,
                exchangeUserRepository,
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

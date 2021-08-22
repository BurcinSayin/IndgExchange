using Exchange.Core.Item.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Core.Tests.Item.Strategy
{
    [TestFixture]
    public class UpdateItemWithTransactionTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private UpdateItemWithTransaction CreateUpdateItemWithTransaction()
        {
            return new UpdateItemWithTransaction();
        }

        [Test]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var updateItemWithTransaction = this.CreateUpdateItemWithTransaction();
            IItemRepository itemRepository = null;
            IExchangeUserRepository exchangeUserRepository = null;
            UpdateItemCommand command = null;

            // Act
            var result = updateItemWithTransaction.Update(
                itemRepository,
                exchangeUserRepository,
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

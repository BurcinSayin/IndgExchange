using Exchange.Core.Item.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Core.Tests.Item.Strategy
{
    [TestFixture]
    public class UpdateItemWithTransactionTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IExchangeUserRepository> mockExchangeUserRepository;
        private Mock<IDataTransaction> mockTransaction;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockExchangeUserRepository = mockRepository.Create<IExchangeUserRepository>();
            mockTransaction = mockRepository.Create<IDataTransaction>();
        }

        private UpdateItemWithTransaction CreateUpdateItemWithTransaction()
        {
            return new UpdateItemWithTransaction();
        }

        [Test]
        public void Update_AllOk_Success()
        {
            var updateItemWithTransaction = this.CreateUpdateItemWithTransaction();
            UpdateItemCommand command = new UpdateItemCommand()
            {
                ItemId = 17,
                HolderId = 42,
                ItemName = "Test Item"
            };
            
            mockItemRepository.Setup(ir => ir.BeginTransaction()).Returns(mockTransaction.Object);
            mockItemRepository.Setup(ir => ir.FindById(It.IsAny<int>(), It.IsAny<IDataTransaction>()))
                .Returns(new Domain.Item.Entity.Item(){Id = command.ItemId});
            mockExchangeUserRepository.Setup(ur => ur.FindById(It.IsAny<int>(), It.IsAny<IDataTransaction>())).Returns(
                new Domain.ExchangeUser.Entity.ExchangeUser()
                {
                    Id = command.HolderId.Value,
                    Name = "Douglas Adams",
                    ItemList = null
                }
            );
            Domain.Item.Entity.Item updatedItem = null;
            mockItemRepository.Setup(ir => ir.Update(It.IsAny<Domain.Item.Entity.Item>()))
                .Returns(new Domain.Item.Entity.Item())
                .Callback<Domain.Item.Entity.Item>(item => updatedItem = item);
            mockTransaction.Setup(t => t.Commit());

            // Act
            var result = updateItemWithTransaction.Update(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            Assert.AreEqual(command.ItemId,updatedItem.Id);
            Assert.AreEqual(command.HolderId.Value,updatedItem.Holder.Id);
            Assert.AreEqual(command.ItemName,updatedItem.ItemName);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void Update_NotExistItem_ThrowNotFount()
        {
            var updateItemWithTransaction = this.CreateUpdateItemWithTransaction();
            UpdateItemCommand command = new UpdateItemCommand()
            {
                ItemId = 17,
                HolderId = 42,
                ItemName = "Test Item"
            };
            
            mockItemRepository.Setup(ir => ir.BeginTransaction()).Returns(mockTransaction.Object);
            mockItemRepository.Setup(ir => ir.FindById(It.IsAny<int>(), It.IsAny<IDataTransaction>()))
                .Returns(() => null);
            mockTransaction.Setup(t => t.Rollback());

            
            
            var ex = Assert.Throws<NotFoundException>(() =>
            {
                updateItemWithTransaction.Update(
                    mockItemRepository.Object,
                    mockExchangeUserRepository.Object,
                    command);
            });


            Assert.AreEqual("Item Not Found.",ex.Message);
            this.mockRepository.VerifyAll();
        }
    }
}

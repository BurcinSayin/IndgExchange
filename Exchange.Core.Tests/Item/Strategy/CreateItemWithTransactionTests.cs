using Exchange.Core.Item.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Data.Sqlite;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Core.Tests.Item.Strategy
{
    [TestFixture]
    public class CreateItemWithTransactionTests
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

        private CreateItemWithTransaction CreateCreateItemWithTransaction()
        {
            return new CreateItemWithTransaction();
        }

        [Test]
        public void Create_AllOk_CreateItem()
        {
            var createItemWithTransaction = this.CreateCreateItemWithTransaction();
            CreateItemCommand command = new CreateItemCommand(){ItemName = "Test Item",OwnerId = 42};
            var repoResult = new Domain.Item.Entity.Item() { Id = 333 };

            mockItemRepository.Setup(ir => ir.BeginTransaction()).Returns(mockTransaction.Object);
            mockExchangeUserRepository.Setup(ur => ur.FindById(It.IsAny<int>(), It.IsAny<IDataTransaction>())).Returns(
                new Domain.ExchangeUser.Entity.ExchangeUser()
                {
                    Id = command.OwnerId.Value,
                    Name = "Douglas Adams",
                    ItemList = null
                }
            );
            mockItemRepository.Setup(ir => ir.Add(It.IsAny<Domain.Item.Entity.Item>()))
                .Returns(repoResult);
            mockTransaction.Setup(t => t.Commit());


            var result = createItemWithTransaction.Create(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            
            Assert.AreEqual(repoResult,result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void Create_InvalidOwner_CreateWithoutOwner()
        {
            var createItemWithTransaction = this.CreateCreateItemWithTransaction();
            CreateItemCommand command = new CreateItemCommand(){ItemName = "Test Item",OwnerId = 42};

            
            mockItemRepository.Setup(ir => ir.BeginTransaction()).Returns(mockTransaction.Object);
            mockExchangeUserRepository.Setup(ur => ur.FindById(It.IsAny<int>(), It.IsAny<IDataTransaction>())).Returns(
                () => null
            );
            Domain.Item.Entity.Item addedObject = null;
            mockItemRepository.Setup(ir => ir.Add(It.IsAny<Domain.Item.Entity.Item>()))
                .Returns(new Domain.Item.Entity.Item())
                .Callback<Domain.Item.Entity.Item>(added => addedObject = added);
            mockTransaction.Setup(t => t.Commit());


            var result = createItemWithTransaction.Create(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            

            this.mockRepository.VerifyAll();
            // Assert
            Assert.AreEqual(command.ItemName,addedObject.ItemName);
            Assert.IsNull(addedObject.Holder);
        }
    }
}

using Exchange.Core.Item.Strategy;
using Exchange.Core.ItemTransaction.Strategy;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.ItemTransaction.Command;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.ItemTransaction.Strategy
{
    public class CreateItemTransactionWithTransactionTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IUserRepository> mockUserRepository;
        private Mock<IItemTransactionRepository> mockItemTransactionRepository; 
        private Mock<IDataTransaction> mockTransaction;
        

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockUserRepository = mockRepository.Create<IUserRepository>();
            mockItemTransactionRepository = mockRepository.Create<IItemTransactionRepository>();
            
            mockTransaction = mockRepository.Create<IDataTransaction>();
        }

        private CreateItemTransactionWithTransaction CreateStrategy()
        {
            return new CreateItemTransactionWithTransaction();
        }
        
        [Test]
        public void Create_AllOk_CreateItem()
        {
            var strategy = this.CreateStrategy();
            CreateItemTransactionCommand command = new CreateItemTransactionCommand()
            {
                GivenItemId = 42,
                TakingUserId = 42
            };
            var repoResult = new Domain.ItemTransaction.Entity.ItemTransaction()
            {
                Id = 42,
                GivenItemId = command.GivenItemId,
                TakingUserId = command.TakingUserId
            };

            mockItemTransactionRepository.Setup(ir => ir.BeginTransaction()).Returns(mockTransaction.Object);
            mockUserRepository.Setup(ur => ur.FindById(It.IsAny<int>(), It.IsAny<IDataTransaction>())).Returns(
                new Domain.User.Entity.User()
                {
                    Id = command.TakingUserId,
                    Name = "Douglas Adams",
                    Items = null
                }
            );
            mockItemRepository.Setup(ur => ur.FindById(It.IsAny<int>(), It.IsAny<IDataTransaction>())).Returns(
                new Domain.Item.Entity.Item()
                {
                    Id = command.GivenItemId,
                    ItemName = "Digital Watch",
                }
            );
            mockItemRepository.Setup(ir => ir.Update(It.IsAny<Domain.Item.Entity.Item>()))
                .Returns(new Domain.Item.Entity.Item());
            
            mockItemTransactionRepository.Setup(ir => ir.Add(It.IsAny<Domain.ItemTransaction.Entity.ItemTransaction>()))
                .Returns(repoResult);
            mockTransaction.Setup(t => t.Commit());


            var result = strategy.Create(
                mockItemRepository.Object,
                mockUserRepository.Object,
                mockItemTransactionRepository.Object,
                command);

            
            Assert.AreEqual(repoResult,result);
            this.mockRepository.VerifyAll();
        }
    }
}
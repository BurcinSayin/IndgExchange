using Exchange.Core.Item.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Core.Shared;
using Exchange.Data.Sqlite;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Core.Tests.Item.Strategy
{
    [TestFixture]
    public class UpdateItemSimpleTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IUserRepository> mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockUserRepository = mockRepository.Create<IUserRepository>();
        }

        private UpdateItemSimple CreateUpdateItemSimple()
        {
            return new UpdateItemSimple();
        }

        [Test]
        public void Update_AllOk_ExpectedBehavior()
        {
            // Arrange
            var updateItemSimple = this.CreateUpdateItemSimple();
            UpdateItemCommand command = new UpdateItemCommand()
            {
                HolderId = 17,
                ItemId = 42,
                ItemName = "Update Item"
            };

            mockItemRepository.Setup(ir => ir.Get(It.IsAny<int>())).Returns(new Domain.Item.Entity.Item()
            {
                Id = command.ItemId
            });
            mockUserRepository.Setup(ur => ur.Get(It.IsAny<int>())).Returns(
                new Domain.User.Entity.User()
                {
                    Id = command.HolderId.Value
                });
            Domain.Item.Entity.Item updatedItem = null;
            mockItemRepository.Setup(ir => ir.Update(It.IsAny<Domain.Item.Entity.Item>()))
                .Returns(new Domain.Item.Entity.Item())
                .Callback<Domain.Item.Entity.Item>(updated => updatedItem = updated);
            

            // Act
            var result = updateItemSimple.Update(
                mockItemRepository.Object,
                mockUserRepository.Object,
                command);

            // Assert
            Assert.AreEqual(command.ItemId,updatedItem.Id);
            Assert.AreEqual(command.HolderId.Value,updatedItem.User.Id);
            Assert.AreEqual(command.ItemName,updatedItem.ItemName);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void Update_NotExistItem_ThrowNotFount()
        {
            var updateItemSimple = this.CreateUpdateItemSimple();
            UpdateItemCommand command = new UpdateItemCommand()
            {
                HolderId = 17,
                ItemId = 42,
                ItemName = "Update Item"
            };

            mockItemRepository.Setup(ir => ir.Get(It.IsAny<int>())).Returns(() => null);


            var ex = Assert.Throws<NotFoundException>(() =>
            {
                updateItemSimple.Update(
                    mockItemRepository.Object,
                    mockUserRepository.Object,
                    command);
            });
            


            Assert.AreEqual("Item Not Found.",ex.Message);

            this.mockRepository.VerifyAll();
        }
    }
}

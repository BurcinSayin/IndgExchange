using System;
using System.Collections.Generic;
using System.Linq;
using Exchange.Core.Item.Service;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Query;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.Item.Service
{
    [TestFixture]
    public class ItemReadServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
        }

        private ItemReadService CreateService()
        {
            return new ItemReadService(mockItemRepository.Object);
        }

        [Test]
        public void GetItem_AllOk_Success()
        {
            // Arrange
            var service = CreateService();
            GetItemQuery query = new GetItemQuery()
            {
                ItemId = 42
            };
            mockItemRepository.Setup(ir => ir.Get(It.IsAny<int>()))
                .Returns(new Domain.Item.Entity.Item()
                {
                    Id = query.ItemId
                });

            // Act
            var result = service.GetItem(query);

            // Assert
            Assert.AreEqual(query.ItemId,result.Id);
            mockRepository.VerifyAll();
        }
        
        [Test]
        public void GetItem_InvalidQuery_ValidationException()
        {
            // Arrange
            var service = CreateService();
            GetItemQuery query = new GetItemQuery()
            {
                ItemId = 0
            };

            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.GetItem(query);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }

        [Test]
        public void GetItems_AllOk_Success()
        {
            var service = CreateService();
            GetItemsWithPagingQuery query = new GetItemsWithPagingQuery()
            {
                PageNumber = 1,
                PageSize = 10
            };
            List<Domain.Item.Entity.Item> mockResponse = new List<Domain.Item.Entity.Item>();
            for (int i = 0; i < 15; i++)
            {
                mockResponse.Add(new Domain.Item.Entity.Item()
                {
                    Id = i+1
                });
            }
            mockItemRepository.Setup(ir => ir.GetAll()).Returns(mockResponse.AsQueryable());

            var result = service.GetItems(query);

            Assert.AreEqual(15,result.TotalCount);
            Assert.AreEqual(1,result.PageIndex);
            Assert.IsTrue(result.HasNextPage);
            CollectionAssert.IsNotEmpty(result.Results);
            Assert.AreEqual(10,result.Results.Count);
            mockRepository.VerifyAll();
        }

        [Test]
        public void GetItems_InvalidQuery_ValidationException()
        {
            var service = CreateService();
            GetItemsWithPagingQuery query = new GetItemsWithPagingQuery()
            {
                PageSize = -1
            };
            
            var nullException =Assert.Throws<ValidationException>(() =>
            {
                service.GetItems(null);
            });
            var propException =Assert.Throws<ValidationException>(() =>
            {
                service.GetItems(query);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(nullException);
            Assert.IsInstanceOf<ValidationException>(propException);
            Console.WriteLine(nullException.Message);
            mockRepository.VerifyAll();
        }
    }
}

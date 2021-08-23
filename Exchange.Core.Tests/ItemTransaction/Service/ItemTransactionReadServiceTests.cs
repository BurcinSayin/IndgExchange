using System;
using System.Collections.Generic;
using System.Linq;
using Exchange.Core.Item.Service;
using Exchange.Core.ItemTransaction.Service;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Query;
using Exchange.Domain.ItemTransaction.Query;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.ItemTransaction.Service
{
    [TestFixture]
    public class ItemTransactionReadServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemTransactionRepository> mockItemTransactionRepository;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemTransactionRepository = mockRepository.Create<IItemTransactionRepository>();
        }
        
        private ItemTransactionReadService CreateService()
        {
            return new ItemTransactionReadService(mockItemTransactionRepository.Object);
        }

        [Test]
        public void GetItem_AllOk_Success()
        {
            // Arrange
            var service = CreateService();
            GetItemTransactionQuery query = new GetItemTransactionQuery()
            {
                ItemTransactionId = 42
            };
            mockItemTransactionRepository.Setup(ir => ir.Get(It.IsAny<int>()))
                .Returns(new Domain.ItemTransaction.Entity.ItemTransaction()
                {
                    Id = query.ItemTransactionId
                });

            // Act
            var result = service.GetItemTransaction(query);

            // Assert
            Assert.AreEqual(query.ItemTransactionId,result.Id);
            mockRepository.VerifyAll();
        }
        
        [Test]
        public void GetItem_InvalidQuery_ValidationException()
        {
            // Arrange
            var service = CreateService();
            GetItemTransactionQuery query = new GetItemTransactionQuery()
            {
                ItemTransactionId = 0
            };

            var ex =Assert.Throws<ValidationException>(() =>
            {
                service.GetItemTransaction(query);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            mockRepository.VerifyAll();
        }

        [Test]
        public void GetItems_AllOk_Success()
        {
            var service = CreateService();
            GetItemTransactionsWithPagingQuery query = new GetItemTransactionsWithPagingQuery()
            {
                PageNumber = 1,
                PageSize = 10
            };
            List<Domain.ItemTransaction.Entity.ItemTransaction> mockResponse = new List<Domain.ItemTransaction.Entity.ItemTransaction>();
            for (int i = 0; i < 15; i++)
            {
                mockResponse.Add(new Domain.ItemTransaction.Entity.ItemTransaction()
                {
                    Id = i+1
                });
            }
            mockItemTransactionRepository.Setup(ir => ir.GetAll()).Returns(mockResponse.AsQueryable());

            var result = service.GetItemTransactions(query);

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
            GetItemTransactionsWithPagingQuery query = new GetItemTransactionsWithPagingQuery()
            {
                PageSize = -1
            };
            
            var nullException =Assert.Throws<ValidationException>(() =>
            {
                service.GetItemTransaction(null);
            });
            var propException =Assert.Throws<ValidationException>(() =>
            {
                service.GetItemTransactions(query);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(nullException);
            Assert.IsInstanceOf<ValidationException>(propException);
            Console.WriteLine(nullException.Message);
            mockRepository.VerifyAll();
        }
        
        
    }
}
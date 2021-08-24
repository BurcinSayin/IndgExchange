using System.Collections.Generic;
using System.Linq;
using Exchange.Core.User.Service;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Query;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.User.Service
{
    [TestFixture]
    public class UserReadServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IUserRepository> mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUserRepository = this.mockRepository.Create<IUserRepository>();
        }

        private UserReadService CreateService()
        {
            return new UserReadService(this.mockUserRepository.Object);
        }

        [Test]
        public void GetItem_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            GetUserQuery query = new GetUserQuery()
            {
                UserId = 42
            };
            mockUserRepository.Setup(ur => ur.Get(It.IsAny<int>())).Returns(new Domain.User.Entity.User());

            // Act
            var result = service.GetUser(query);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void GetItem_InvalidQuery_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            GetUserQuery query = new GetUserQuery();

            var ex = Assert.Throws<ValidationException>(() =>
            {
                service.GetUser(query);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            this.mockRepository.VerifyAll();
        }


        [Test]
        public void FindItems_AllOk_Success()
        {
            // Arrange
            var service = this.CreateService();
            GetUsersWithPagingQuery query = new GetUsersWithPagingQuery()
            {
                PageSize = 10,
                PageNumber = 1
            };
            List<Domain.User.Entity.User> mockResponse = new List<Domain.User.Entity.User>();
            for (int i = 0; i < 15; i++)
            {
                mockResponse.Add(new Domain.User.Entity.User()
                {
                    Id = i+1
                });
            }
            mockUserRepository.Setup(ur => ur.GetAll()).Returns(mockResponse.AsQueryable());

            // Act
            var result = service.GetUsers(query);

            // Assert
            Assert.AreEqual(15,result.TotalCount);
            Assert.AreEqual(1,result.PageIndex);
            Assert.IsTrue(result.HasNextPage);
            CollectionAssert.IsNotEmpty(result.Results);
            Assert.AreEqual(10,result.Results.Count);
            this.mockRepository.VerifyAll();
        }
        
        [Test]
        public void FindItems_InvalidQuery_ThrowValidationEx()
        {
            // Arrange
            var service = this.CreateService();
            GetUsersWithPagingQuery query = new GetUsersWithPagingQuery()
            {
                PageSize = -1
            };

            var ex = Assert.Throws<ValidationException>(() =>
            {
                service.GetUsers(query);
            });

            // Assert
            Assert.IsInstanceOf<ValidationException>(ex);
            this.mockRepository.VerifyAll();
        }
    }
}

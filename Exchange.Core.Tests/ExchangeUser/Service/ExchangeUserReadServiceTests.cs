using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Core.ExchangeUser.Service;
using Exchange.Domain.ExchangeUser.Query;

namespace Exchange.Services.Tests
{
    [TestFixture]
    public class ExchangeUserReadServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IExchangeUserRepository> mockExchangeUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockExchangeUserRepository = this.mockRepository.Create<IExchangeUserRepository>();
        }

        private ExchangeUserReadService CreateService()
        {
            return new ExchangeUserReadService(
                this.mockExchangeUserRepository.Object);
        }

        [Test]
        public void GetItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            GetUserQuery query = new GetUserQuery();

            // Act
            var result = service.GetExchangeUser(query);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindItems_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            GetUsersWithPagingQuery query = null;

            // Act
            var result = service.GetExchangeUsers(query);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

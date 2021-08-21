using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.ServiceInterfaces.Queries;

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
            int id = 0;

            // Act
            var result = service.GetItem(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindItems_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            FindUsersWithPagingQuery query = null;

            // Act
            var result = service.FindItems(
                query);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

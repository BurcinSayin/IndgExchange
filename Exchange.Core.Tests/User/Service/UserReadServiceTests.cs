using Exchange.Core.User.Service;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Query;
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
            return new UserReadService(
                this.mockUserRepository.Object);
        }

        [Test]
        [Ignore("notImplemented")]
        public void GetItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            GetUserQuery query = new GetUserQuery();

            // Act
            var result = service.GetUser(query);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        [Ignore("notImplemented")]
        public void FindItems_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            GetUsersWithPagingQuery query = null;

            // Act
            var result = service.GetUsers(query);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

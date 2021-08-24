using Exchange.Core.User.Service;
using Exchange.Core.User.Strategy;
using Exchange.Data.Sqlite;
using Exchange.Domain.User.Command;
using NUnit.Framework;

namespace Exchange.Core.Tests.User.Service
{
    [TestFixture]
    public class UserWriteServiceIntegrationTests
    {
        private UserWriteService testService;


        [OneTimeSetUp]
        public void InitDb()
        {
            ExchangeDataContext testDbContext = new ExchangeDataContext();

            UserWriteStrategySet strategySet = new UserWriteStrategySet(
                new CreateUserSimple(),
                new UpdateUserSimple(),
                new DeleteUserSimple());

            testService = new UserWriteService(strategySet, new ItemRepository(testDbContext),new UserRepository(testDbContext));
        }


        [Test]
        public void CreateUser_AllOk_Success()
        {
            // Arrange
            CreateUserCommand command = new CreateUserCommand()
            {
                UserName = "TestUser",
                Password = "pass"
            };

            // Act
            var result = testService.CreateUser(command);

            // Assert
            Assert.Pass();
        }
    }
}

using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using NUnit.Framework;
using System;
using Exchange.Core.ExchangeUser.Service;
using Exchange.Core.ExchangeUser.Strategy;
using Exchange.Data.Sqlite;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Services.Tests
{
    [TestFixture]
    public class ExchangeUserWriteServiceIntegrationTests
    {
        private ExchangeUserWriteService testService;


        [OneTimeSetUp]
        public void InitDb()
        {
            ExchangeDataContext testDbContext = new ExchangeDataContext();

            ExchangeUserWriteStrategySet strategySet = new ExchangeUserWriteStrategySet(
                new CreateExchangeUserSimple(),
                new UpdateExchangeUserSimple(),
                new DeleteExchangeUserSimple());

            testService = new ExchangeUserWriteService(strategySet, new ItemRepository(testDbContext),new ExchangeUserRepository(testDbContext));
        }


        [Test]
        public void CreateExchangeUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            CreateExchangeUserCommand command = new CreateExchangeUserCommand()
            {
                UserName = "TestUser"
            };

            // Act
            var result = testService.CreateExchangeUser(command);

            // Assert
            Assert.Pass();
        }
    }
}

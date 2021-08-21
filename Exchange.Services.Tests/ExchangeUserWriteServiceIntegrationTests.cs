using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using NUnit.Framework;
using System;
using Exchange.Data.Sqlite;
using Exchange.Domain.ServiceInterfaces.Commands;

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


            testService = new ExchangeUserWriteService(new ExchangeUserRepository(testDbContext));
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

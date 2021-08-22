using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Core.ExchangeUser.Service;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Services.Tests
{
    [TestFixture]
    public class ExchangeUserWriteServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IExchangeUserRepository> mockExchangeUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockItemRepository = this.mockRepository.Create<IItemRepository>();
            this.mockExchangeUserRepository = this.mockRepository.Create<IExchangeUserRepository>();
        }

        private ExchangeUserWriteService CreateService()
        {
            return new ExchangeUserWriteService(this.mockItemRepository.Object,
                this.mockExchangeUserRepository.Object);
        }

        [Test]
        public void CreateExchangeUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            CreateExchangeUserCommand command = null;

            // Act
            var result = service.CreateExchangeUser(
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
        
        // [Test]
        // public void Create_NullCommand_ValidationException()
        // {
        //     // Arrange
        //     var createExchangeUserSimple = this.CreateCreateExchangeUserSimple();
        //     CreateExchangeUserCommand command = null;
        //
        //     // Act
        //     var result = createExchangeUserSimple.Create(
        //         mockItemRepository.Object,
        //         mockExchangeUserRepository.Object,
        //         command);
        //
        //     // Assert
        //     Assert.Fail();
        //     this.mockRepository.VerifyAll();
        // }
        //
        // [Test]
        // public void Create_EmptyUserName_ValidationException()
        // {
        //     var createExchangeUserSimple = this.CreateCreateExchangeUserSimple();
        //     CreateExchangeUserCommand command = null;
        //
        //     var result = createExchangeUserSimple.Create(
        //         mockItemRepository.Object,
        //         mockExchangeUserRepository.Object,
        //         command);
        //
        //     Assert.Fail();
        //     this.mockRepository.VerifyAll();
        // }
    }
}

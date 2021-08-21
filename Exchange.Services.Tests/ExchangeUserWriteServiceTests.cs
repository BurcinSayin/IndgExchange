﻿using Exchange.Domain.DataInterfaces;
using Exchange.Services;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Services.Tests
{
    [TestFixture]
    public class ExchangeUserWriteServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IExchangeUserRepository> mockExchangeUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockExchangeUserRepository = this.mockRepository.Create<IExchangeUserRepository>();
        }

        private ExchangeUserWriteService CreateService()
        {
            return new ExchangeUserWriteService(
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
    }
}

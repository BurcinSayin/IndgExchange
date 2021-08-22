﻿using Exchange.Core.Item.Strategy;
using Moq;
using NUnit.Framework;
using System;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Core.Tests.Item.Strategy
{
    [TestFixture]
    public class DeleteItemSimpleTests
    {
        private MockRepository mockRepository;
        private Mock<IItemRepository> mockItemRepository;
        private Mock<IExchangeUserRepository> mockExchangeUserRepository;


        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockExchangeUserRepository = mockRepository.Create<IExchangeUserRepository>();
        }

        private DeleteItemSimple CreateDeleteItemSimple()
        {
            return new DeleteItemSimple();
        }

        [Test]
        public void Delete_AlOk_Success()
        {
            var deleteItemSimple = this.CreateDeleteItemSimple();
            DeleteItemCommand command = new DeleteItemCommand()
            {
                ItemId = 42
            };

            mockItemRepository.Setup(ir => ir.Delete(It.IsAny<int>())).Returns(true);
            

            // Act
            var result = deleteItemSimple.Delete(
                mockItemRepository.Object,
                mockExchangeUserRepository.Object,
                command);

            // Assert
            Assert.IsTrue(result);
            this.mockRepository.VerifyAll();
        }
    }
}
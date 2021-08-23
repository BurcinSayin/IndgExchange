using Exchange.Data.Sqlite;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using Exchange.Domain.Item.Entity;
using Exchange.Domain.ItemTransaction.Entity;
using Exchange.Domain.User.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exchange.Data.Sqlite.Tests
{
    [TestFixture]
    public class ItemTransactionRepositoryIntegrationTests
    {
        private ExchangeDataContext testDataContext;



        private int userId;
        private Item testItem;
        private User testUser;

        [OneTimeSetUp]
        public void InitTestDb()
        {
            testDataContext = new ExchangeDataContext();

            testItem = new Item() { ItemName = "TestItem" };
            testUser = new User() { Name = "TestUser" };

            ItemRepository itemRepository = new ItemRepository(testDataContext);
            itemRepository.Add(testItem);

            UserRepository userRepository = new UserRepository(testDataContext);
            userRepository.Add(testUser);;
        }

        [Test]
        public void test()
        {
            ItemTransactionRepository toTest = new ItemTransactionRepository(testDataContext);

            var testTRansaction = new ItemTransaction()
            {
                CreatedAt = DateTime.Now,
                GivenItemId = testItem.Id,
                TakingUserId = testUser.Id
            };

            var result = toTest.Add(testTRansaction);

            
            Console.WriteLine(result.Id);

            var tranList = toTest.GetAll().ToList();

            foreach (ItemTransaction tran in tranList)
            {
                Console.WriteLine(tran.Id);
            }

        }
    }
}

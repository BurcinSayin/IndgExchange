using Exchange.Core.User.Strategy;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Moq;
using NUnit.Framework;

namespace Exchange.Core.Tests.User.Strategy
{
    [TestFixture]
    public class CreateUserSimpleTests
    {
        private MockRepository mockRepository;

        private Mock<IItemRepository> mockItemRepository;
        private Mock<IUserRepository> mockUserRepository;


        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            mockItemRepository = mockRepository.Create<IItemRepository>();
            mockUserRepository = mockRepository.Create<IUserRepository>();

        }

        private CreateUserSimple CreateCreateUserSimple()
        {
            return new CreateUserSimple();
        }

        [Test]
        public void Create_AllOk_CallRepoAdd()
        {
            var createUserSimple = this.CreateCreateUserSimple();
            CreateUserCommand command = new CreateUserCommand()
            {
                UserName = "Test User"
            };

            var result = createUserSimple.Create(
                mockItemRepository.Object,
                mockUserRepository.Object,
                command);

            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

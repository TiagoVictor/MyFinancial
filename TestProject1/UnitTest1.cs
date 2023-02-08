using Microsoft.Extensions.DependencyInjection;
using MyFinancial.Data.Context;
using MyFinancial.Data.Repository;
using MyFinancial.Data.Repository.Interface;
using MyFinancial.Service;
using MyFinancial.Service.Interface;

namespace TestProject1
{
    public class Tests
    {
        private readonly IUserService _userService;

        public Tests()
        {
            var service = new ServiceCollection();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<AppDbContext>();
            var provider = service.BuildServiceProvider();

            _userService = provider.GetRequiredService<IUserService>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {

            var teste = _userService.GetAllUsersAsync();

            Assert.Pass();
        }
    }
}
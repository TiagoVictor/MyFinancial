using MyFinancial.Controllers;
using MyFinancial.Data.DataModel;
using MyFinancial.Service.Interface;
using MyFinancialTestApi.UserTest;

namespace MyFinancialTestApi.IncomeTest
{
    public class IncomeControllerTeste
    {
        IncomeController _incomeController;
        IUserService _userService;
        IIncomeService _incomeService;

        public IncomeControllerTeste()
        {
            _userService = new UserServiceTest();
            _incomeService = new IncomeServiceTeste();
            _incomeController = new IncomeController(_incomeService, _userService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnOkResult()
        {
            // Act
            var okResult = _incomeController.GetAll();
            var items = Assert.IsType<List<Income>>(okResult.Result);

            // Assert
            Assert.NotEmpty(items);
        }

        [Fact]
        public void Get_WhenCalled_ReturnAllItems()
        {
            // Act
            var okResult = _incomeController.GetAll();

            // Assert
            var items = Assert.IsType<List<Income>>(okResult.Result);
            Assert.Equal(2, items.Count());
        }
    }
}

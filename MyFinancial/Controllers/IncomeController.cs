using Microsoft.AspNetCore.Mvc;
using MyFinancial.Data.DataModel;
using MyFinancial.Dto;
using MyFinancial.Service.Interface;

namespace MyFinancial.Controllers
{
    [Route("Income")]
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IUserService _userService;

        public IncomeController(IIncomeService incomeService, IUserService userService)
        {
            _incomeService = incomeService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _incomeService.GetAllIncomesAsync();

            foreach (var income in list)
            {
                income.User = await _userService.GetUserByIdAsync(income.UserId);
            }

            return View(new IndexIncomeDto
            {
                List = list
            });
        }

        [HttpGet("NewIncome")]
        public IActionResult NewIncome()
        {
            return View(new IncomeDto());
        }

        [HttpPost("Income")]
        public async Task<IActionResult> PostAsync(
            IncomeDto dto,
            [FromServices] IIncomeService _incomeService
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _incomeService.SaveIncomeAsync(dto);

            return Created($"v1/Income/{dto.Amount}", dto);
        }

        [HttpPut("Income/{id}")]
        public IActionResult EditAsync(
            [FromBody] IncomeDto dto,
            [FromRoute] int id,
            [FromServices] IIncomeService _incomeService
            )
        {
            if (!ModelState.IsValid || id == 0)
                return BadRequest();

            _incomeService.UpdateIncome(dto);
            return Ok();
        }

        [HttpDelete("Income/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] IIncomeService _incomeService
            )
        {
            if (id == 0)
                return BadRequest();

            await _incomeService.DeleteIncome(id);
            return Ok();
        }

        [HttpGet("Income")]
        public async Task<Income> GetById(int id)
        {
            return await _incomeService.GetIncomeAsync(id);
        }

        [HttpGet("Incomes")]
        public async Task<IEnumerable<Income>> GetAll()
        {
            return await _incomeService.GetAllIncomesAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyFinancial.Data.DataModel;
using MyFinancial.Dto;
using MyFinancial.Service.Interface;

namespace MyFinancial.Controllers
{
    [Route("v1")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("User")]
        public async Task<IActionResult> PostAsync(
            [FromBody] UserDto dto,
            [FromServices] IUserService _userService
            )
        {
            if(!ModelState.IsValid)
                return BadRequest();

            await _userService.SaveUserAsync(dto);

            return Created($"v1/document/{dto.Name}", dto);
        }

        [HttpPut("User/{id}")]
        public async Task<IActionResult> EditAsync(
            [FromBody] UserDto dto,
            [FromRoute] int id,
            [FromServices] IUserService _userService
            )
        {
            if (!ModelState.IsValid || id == 0)
                return BadRequest();

            _userService.UpdateUser(dto);
            return Ok();
        }


        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] IUserService _userService
            )
        {
            if(id == 0)
                return BadRequest();

            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpGet("Users")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAllUsersAsync();
        }

        [HttpGet("User/{id}")]
        public async Task<User> GetById(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }
    }
}

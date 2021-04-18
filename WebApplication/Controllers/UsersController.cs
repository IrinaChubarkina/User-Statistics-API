using System.Threading.Tasks;
using Domain.Core.Abstractions.Services;
using Domain.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger,
            ICalculationService calculationService,
            IUserService userService)
        {
            _logger = logger;
            _calculationService = calculationService;
            _userService = userService;
        }

        [HttpGet]
        [Route("calculate")]
        public IActionResult Calculate()
        {
            const int days = 7;
            var result = _calculationService.GetStatisticsForDay(days);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("list")]
        public IActionResult GetAllUsers()
        {
            var users =_userService.GetAll();
            return Ok(users);
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUser([FromBody]UserDto user)
        {
            var id = await _userService.AddUserAsync(user);
            return Ok(id);
        }
    }
}
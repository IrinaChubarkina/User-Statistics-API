using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Calculation;

namespace WebApp.Controllers
{
    [ApiController]
    public class UserApiController : Controller
    {
        private readonly ICalculateService _calculateService;

        public UserApiController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        public IActionResult Index()
        {
            return Ok();
        }
         
        public async Task<IActionResult> Retention()
        {
            await _calculateService.CalculateRollingRetention();
            return Ok();
        }
    }
}
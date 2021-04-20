using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Core.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly IMapper _mapper;

        public StatisticsController(ICalculationService calculationService, IMapper mapper)
        {
            _calculationService = calculationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Calculate()
        {
            const int days = 7;
            var rollingRetention = await _calculationService.GetRollingRetentionForDay(days);
            var distribution = await _calculationService.GetLifeTimeDistribution();
            
            var columns = _mapper.Map<IEnumerable<HistogramColumn>>(distribution);
            var response = new Statistics { HistogramColumns = columns, RollingRetention = rollingRetention};
            
            return Ok(response);
        }
    }
}
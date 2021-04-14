using Domain.Core.Dtos;

namespace Domain.Core.Abstractions.Services
{
    public interface ICalculationService
    {
        CalculationResult GetStatisticsForDay(int day);
    }
}
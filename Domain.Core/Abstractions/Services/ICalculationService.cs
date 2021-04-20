using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Dtos;

namespace Domain.Core.Abstractions.Services
{
    public interface ICalculationService
    {
        Task<IEnumerable<UserGroup>> GetLifeTimeDistribution();
        Task<double> GetRollingRetentionForDay(int day);
    }
}
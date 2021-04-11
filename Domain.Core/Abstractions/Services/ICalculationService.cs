using System.Threading.Tasks;

namespace Domain.Core.Abstractions.Services
{
    public interface ICalculateService
    {
        Task CalculateRollingRetention();
    }
}
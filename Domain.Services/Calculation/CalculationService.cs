using System.Threading.Tasks;
using Domain.Core.Abstractions.Repositories;
using Domain.Core.Abstractions.Services;

namespace Domain.Services.Calculation
{
    public class CalculationService : ICalculationService
    {
        private readonly IUserRepository _userRepository;

        public CalculationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
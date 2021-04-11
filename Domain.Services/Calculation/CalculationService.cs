using System.Threading.Tasks;
using Domain.Core.Repositories;
using Domain.Core.Services;

namespace Domain.Services.Calculation
{
    public class CalculateService : ICalculateService
    {
        private readonly IUserRepository _userRepository;

        public CalculateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task CalculateRollingRetention()
        {
            throw new System.NotImplementedException();
        }
    }
}
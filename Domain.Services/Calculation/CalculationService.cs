using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Abstractions.Repositories;
using Domain.Core.Abstractions.Services;
using Domain.Core.Dtos;
using Domain.Core.Specifications;

namespace Domain.Services.Calculation
{
    public class CalculationService : ICalculationService
    {
        private readonly IUserRepository _userRepository;

        public CalculationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserGroup>> GetLifeTimeDistribution()
        {
            var groups = await _userRepository.GetGroupedByLifeTime();
            return groups.OrderBy(x => x.LifeTime);
        }

        public async Task<double> GetRollingRetentionForDay(int day)
        {
            var lifeTimeSpec = new UsersByLifeTimeSpecification(day);
            var registrationDateSpec = new UsersByRegistrationDateSpecification(day);

            var returningUsersCount = await _userRepository.CountBySpecification(lifeTimeSpec);
            var registeredUsersCount = await _userRepository.CountBySpecification(registrationDateSpec);

            return returningUsersCount / (double) registeredUsersCount * 100;
        }
    }
}
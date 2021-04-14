using System.Linq;
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

        public CalculationResult GetStatisticsForDay(int day)
        {
            var allUsers = _userRepository.GetAll();

            var columns = allUsers
                .GroupBy(x => x.LifeTime)
                .Select(group => new HistogramColumn(group.Count(), group.Key));

            var rollingRetention = GetRollingRetentionForDay(day);
            return new CalculationResult(rollingRetention, columns);
        }
        
        private double GetRollingRetentionForDay(int day)
        {
            var lifeTimeSpec = new UsersByLifeTimeSpecification(day);
            var registrationDateSpec = new UsersByRegistrationDateSpecification(day);

            var returningUsers = _userRepository.GetBySpecification(lifeTimeSpec);
            var registeredUsers = _userRepository.GetBySpecification(registrationDateSpec);

            return returningUsers.Count() / (double) registeredUsers.Count() * 100;
        }
    }
}
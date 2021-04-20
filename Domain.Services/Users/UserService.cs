using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Abstractions.Repositories;
using Domain.Core.Abstractions.Services;
using Domain.Core.Entities;

namespace Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> Add(User user)
        {
            if (user.RegistrationDate > user.LastActivityDate)
            {
                throw new ArgumentException(nameof(User));
            }
            
            await _userRepository.Add(user);
            return user;
        }
    }
}
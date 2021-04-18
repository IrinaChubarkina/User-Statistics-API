using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Core.Abstractions.Repositories;
using Domain.Core.Abstractions.Services;
using Domain.Core.Dtos;
using Domain.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetAll().ToList();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }

        public async Task<int> AddUserAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                await _userRepository.AddUserAsync(user);
                return user.Id;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Can not add user \n");
                throw;
            }
        }
    }
}
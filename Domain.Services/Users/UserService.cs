using System;
using System.Collections.Generic;
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

        public Task AddUsersAsync(IEnumerable<UserDto> userDtos)
        {
            try
            {
                var users = _mapper.Map<IEnumerable<User>>(userDtos);
                return _userRepository.AddUsersAsync(users);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Can not add users \n");
                throw;
            }
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Dtos;

namespace Domain.Core.Abstractions.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        Task<int> AddUserAsync(UserDto user);
    }
}
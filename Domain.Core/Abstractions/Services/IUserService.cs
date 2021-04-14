using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Dtos;

namespace Domain.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task AddUsersAsync(IEnumerable<UserDto> users);
    }
}
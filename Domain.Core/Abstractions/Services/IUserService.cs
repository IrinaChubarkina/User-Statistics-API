using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Entities;

namespace Domain.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Add(User user);
    }
}
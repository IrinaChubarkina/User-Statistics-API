using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using Domain.Core.Dtos;
using Domain.Core.Entities;

namespace Domain.Core.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<int> CountBySpecification(ISpecification<User> spec);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task<IEnumerable<UserGroup>> GetGroupedByLifeTime();
    }
}
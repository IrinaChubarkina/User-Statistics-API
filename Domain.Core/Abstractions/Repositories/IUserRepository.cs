using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Domain.Core.Entities;

namespace Domain.Core.Abstractions.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetBySpecification(ISpecification<User> spec);
        IQueryable<User> GetAll();
        Task AddUsersAsync(IEnumerable<User> users);
    }
}
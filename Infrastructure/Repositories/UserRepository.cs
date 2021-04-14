using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Core.Abstractions.Repositories;
using Domain.Core.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EfContext _context;

        public UserRepository(EfContext context)
        {
            _context = context;
        }
        
        public IQueryable<User> GetBySpecification(ISpecification<User> spec)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(GetAll(), spec);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users
                .AsQueryable()
                .AsNoTracking();
        }

        public async Task AddUsersAsync(IEnumerable<User> users)
        {
            await _context.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }
    }
}
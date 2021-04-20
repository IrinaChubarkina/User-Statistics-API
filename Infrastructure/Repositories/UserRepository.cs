using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Core.Abstractions.Repositories;
using Domain.Core.Dtos;
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
        
        public Task<int> CountBySpecification(ISpecification<User> spec)
        {
            var evaluator = new SpecificationEvaluator();
            var allUsers = _context.Users.AsQueryable().AsNoTracking();
            return evaluator.GetQuery(allUsers, spec).CountAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task Add(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<UserGroup>> GetGroupedByLifeTime()
        {
            return await _context.Users
                .AsQueryable()
                .AsNoTracking()
                .GroupBy(x => x.LifeTime)
                .Select(group => new UserGroup(group.Count(), group.Key))
                .ToListAsync();
        }
    }
}
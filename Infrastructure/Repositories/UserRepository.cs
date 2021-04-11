using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> AddUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
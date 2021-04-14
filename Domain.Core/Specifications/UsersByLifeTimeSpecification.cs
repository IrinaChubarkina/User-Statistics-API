using Ardalis.Specification;
using Domain.Core.Entities;

namespace Domain.Core.Specifications
{
    public sealed class UsersByLifeTimeSpecification : Specification<User>
    {
        public UsersByLifeTimeSpecification(int days)
        {
            Query.Where(user => user.LifeTime >= days);
        }
    }
}
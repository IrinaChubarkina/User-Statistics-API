using System;
using Ardalis.Specification;
using Domain.Core.Entities;

namespace Domain.Core.Specifications
{
    public sealed class UsersByRegistrationDateSpecification : Specification<User>
    {
        public UsersByRegistrationDateSpecification(int days)
        {
            Query.Where(user => (DateTime.UtcNow - user.RegistrationDate).Days >= days);
        }
    }
}
using System;

namespace Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastActivityDate { get; set; }

        public int LifeTime => (LastActivityDate - RegistrationDate).Days;
    }
}
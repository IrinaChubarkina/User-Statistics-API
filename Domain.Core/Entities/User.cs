using System;

namespace Domain.Core.Entities
{
    public class User
    {
        private int _lifeTime;

        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastActivityDate { get; set; }

        public int LifeTime
        {
            get => (LastActivityDate - RegistrationDate).Days;
            private set => _lifeTime = value;
        }
    }
}
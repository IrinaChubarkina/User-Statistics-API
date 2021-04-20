namespace Domain.Core.Dtos
{
    public class UserGroup
    {
        public UserGroup(int count, int lifeTime)
        {
            Count = count;
            LifeTime = lifeTime;
        }

        public int Count { get; }
        public int LifeTime { get; }
    }
}
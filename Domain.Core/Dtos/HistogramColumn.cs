namespace Domain.Core.Dtos
{
    public class HistogramColumn
    {
        public HistogramColumn(int usersCount, int lifeTime)
        {
            UsersCount = usersCount;
            LifeTime = lifeTime;
        }

        public int UsersCount { get; }
        public int LifeTime { get; }
    }
}
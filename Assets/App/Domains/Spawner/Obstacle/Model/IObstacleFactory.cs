using Zenject;

namespace Controllers.Spawner.Obstacle.Model
{
    public class ObstacleOptions
    {
        public int Index { get;}

        public ObstacleOptions(int index)
        {
            Index = index;
        }
    }

    public interface IObstacleView : IView
    {
        bool IsActive { get; set; }

        void UpdateSpeed(float speed);
    }
    
    public interface IObstacleFactory : IFactory<ObstacleOptions, IObstacleView>
    {
    }
    
}
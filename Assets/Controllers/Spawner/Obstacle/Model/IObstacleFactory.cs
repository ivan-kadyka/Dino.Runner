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
    }
    
    public interface IObstacleFactory : IFactory<ObstacleOptions, IObstacleView>
    {
    }
    
}
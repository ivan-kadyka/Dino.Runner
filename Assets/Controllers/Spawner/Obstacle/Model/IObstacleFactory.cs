using UnityEngine;
using Zenject;

namespace Controllers.Spawner.Obstacle.Model
{
    public enum ObstacleType
    {
        Type1,
        Type2,
        Type3
    }
    
    public class ObstacleOptions
    {
        public ObstacleType Type { get; set; }
    }

    public interface IObstacleView : IView
    {
        
    }
    
    public interface IObstacleFactory : IFactory<ObstacleOptions, IObstacleView>
    {
    }
    
}
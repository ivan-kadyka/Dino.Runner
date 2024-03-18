using Controllers.Spawner.Obstacle.Model;
using Zenject;

namespace Controllers.Spawner.Obstacle.Factory
{
    public class ObstacleFactory : PlaceholderFactory<ObstacleOptions, IObstacleView>, IObstacleFactory
    {
        private readonly DiContainer _container;
        private readonly ObstacleScriptableObject _obstacleSo;

        public ObstacleFactory(DiContainer container, ObstacleScriptableObject obstacleSo)
        {
            _container = container;
            _obstacleSo = obstacleSo;
        }

        public override IObstacleView Create(ObstacleOptions options)
        {
            int index = options.Index;

            var obstacleObject = _obstacleSo.items[index];
            
            return _container.InstantiatePrefab(obstacleObject.prefab).GetComponent<IObstacleView>();
        }
    }
}
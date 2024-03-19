using App.Domains.Spawner.View;
using App.Models;
using Controllers.Spawner.Obstacle.Model;
using Zenject;

namespace Controllers.Spawner.Obstacle.Factory
{
    public class ObstacleFactory : PlaceholderFactory<SpawnOptions, ISpawnView>, IObstacleFactory
    {
        private readonly DiContainer _container;
        private readonly ObstacleScriptableObject _obstacleSo;
        private readonly IGameContext _gameContext;

        public ObstacleFactory(DiContainer container, ObstacleScriptableObject obstacleSo, IGameContext gameContext)
        {
            _container = container;
            _obstacleSo = obstacleSo;
            _gameContext = gameContext;
        }

        public override ISpawnView Create(SpawnOptions options)
        {
            int index = options.Id;

            var obstacleObject = _obstacleSo.items[index];
            
            var view = _container.InstantiatePrefab(obstacleObject.prefab).GetComponent<ISpawnView>();
            
            view.SetUp(_gameContext, "Obstacle");

            return view;
        }
    }
}
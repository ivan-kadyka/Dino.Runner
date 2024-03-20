using App.GameCore;
using UnityEngine;
using Zenject;

namespace App.Spawner.Obstacle
{
    public class ObstacleFactory : PlaceholderFactory<SpawnOptions, ISpawnView>, IObstacleFactory
    {
        private readonly DiContainer _container;
        private readonly ObstacleScriptableObject _obstacleSo;
        private readonly IGameContext _gameContext;
        private readonly Transform _parentTransform;

        public ObstacleFactory(
            DiContainer container,
            ObstacleScriptableObject obstacleSo,
            Transform parentTransform,
            IGameContext gameContext)
        {
            _container = container;
            _obstacleSo = obstacleSo;
            _parentTransform = parentTransform;
            _gameContext = gameContext;
        }

        public override ISpawnView Create(SpawnOptions options)
        {
            int index = options.Id;

            var obstacleObject = _obstacleSo.items[index];
            
            var view = _container.InstantiatePrefab(obstacleObject.prefab, _parentTransform).GetComponent<ISpawnView>();
            
            view.SetUp(_gameContext, "Obstacle");

            return view;
        }
    }
}
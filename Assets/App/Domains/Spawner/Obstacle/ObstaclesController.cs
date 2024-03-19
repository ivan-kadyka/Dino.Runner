using System.Threading;
using App.Domains.Spawner.View;
using Controllers.Spawner.Obstacle.Model;
using Cysharp.Threading.Tasks;
using Infra.Controllers;
using Random = UnityEngine.Random;

namespace App.Domains.Spawner.Obstacle
{
    public class ObstaclesController : ControllerBase, ISpawnerController
    {
        private readonly IObstacleSettings _settings;
        
        private readonly SpawnPool<SpawnOptions, ISpawnView> _spawnPool;
        
        public ObstaclesController(IObstacleFactory obstacleFactory, IObstacleSettings settings)
        {
            _settings = settings;
            _spawnPool = new SpawnPool<SpawnOptions, ISpawnView>(obstacleFactory);
            
            _disposables.Add(_spawnPool);
        }
        
        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _spawnPool.Reset();
            
            return base.OnStarted(token);
        }

        public UniTask Spawn(CancellationToken token = default)
        {
            float spawnChance = Random.value;

            for (int i = 0; i < _settings.ObjectChances.Length; i++)
            {
                var currentChance = _settings.ObjectChances[i];
                
                if (spawnChance < currentChance)
                {
                    _spawnPool.GetObject(new SpawnOptions(i));
                    break;
                }

                spawnChance -= currentChance;
            }

            return UniTask.CompletedTask;
        }
    }
}
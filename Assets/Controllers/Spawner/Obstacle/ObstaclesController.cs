using System.Collections.Generic;
using System.Threading;
using Character.Controller;
using Controllers.Spawner.Obstacle.Model;
using Cysharp.Threading.Tasks;
using Models.Tickable;
using UniRx;
using Random = UnityEngine.Random;

namespace Controllers.Spawner.Obstacle
{
    public class ObstaclesController : ControllerBase
    {
        private readonly IObstacleFactory _obstacleFactory;
        private readonly IObstacleSettings _settings;
        private readonly ITickableContext _tickableContext;

        private readonly List<IObstacleView> _obstacles = new List<IObstacleView>();

        private readonly SerialDisposable _spawnDisposable = new SerialDisposable();

        private float _nextSpawnTime;
        
        public ObstaclesController(
            IObstacleFactory obstacleFactory,
            IObstacleSettings settings,
            ITickableContext tickableContext)
        {
            _obstacleFactory = obstacleFactory;
            _settings = settings;
            _tickableContext = tickableContext;
            
            _disposable.Add(_spawnDisposable);
        }
        
        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _spawnDisposable.Disposable = _tickableContext.Updated.Subscribe(OnSpawnUpdate);
            UpdateNextDeltaTime();
            
            return base.OnStarted(token);
        }

        protected override UniTask OnStopped(CancellationToken token = default)
        {
            _spawnDisposable.Disposable = default;
            return base.OnStopped(token);
        }

        private void UpdateNextDeltaTime()
        {
            _nextSpawnTime = Random.Range(_settings.MinSpawnRate, _settings.MaxSpawnRate);
        }

        private bool IsReadyToSpawn(float deltaTime)
        {
            _nextSpawnTime -= deltaTime;
            
            return _nextSpawnTime < 0;
        }
        
        private void OnSpawnUpdate(float deltaTime)
        {
            if (!IsReadyToSpawn(deltaTime))
                return;
            
            float spawnChance = Random.value;

            for (int i = 0; i < _settings.ObjectChances.Length; i++)
            {
                var currentChance = _settings.ObjectChances[i];
                
                if (spawnChance < currentChance)
                {
                    var obstacleView = _obstacleFactory.Create(new ObstacleOptions(i));
                    break;
                }

                spawnChance -= currentChance;
            }

            UpdateNextDeltaTime();
        }
    }
}
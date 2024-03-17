using System.Threading;
using Character.Controller;
using Character.Model;
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

        private readonly SerialDisposable _spawnDisposable = new SerialDisposable();

        private float _nextSpawnTime;

        private readonly ObstaclesPool _obstaclesPool;
        
        public ObstaclesController(
            IObstacleFactory obstacleFactory,
            IObstacleSettings settings,
            ITickableContext tickableContext,
            ICharacterContext characterContext)
        {
            _obstacleFactory = obstacleFactory;
            _settings = settings;
            _tickableContext = tickableContext;
            
            _obstaclesPool = new ObstaclesPool(_obstacleFactory, characterContext);
            
            _disposable.Add(_obstaclesPool);
            _disposable.Add(_spawnDisposable);
        }
        
        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _obstaclesPool.Reset();
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
                    _obstaclesPool.GetObject(i);
                    break;
                }

                spawnChance -= currentChance;
            }

            UpdateNextDeltaTime();
        }
    }
}
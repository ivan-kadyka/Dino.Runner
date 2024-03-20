using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;
using Infra.Controllers;
using UniRx;
using UnityEngine;

namespace App.Domains.Spawner
{
    public class CompositeSpawnerController : ControllerBase
    {
        private readonly SpawnSettings _settings;
        private readonly ISpawnerController _obstacleController;
        private readonly ISpawnerController _coinController;
        private readonly ITickableContext _tickableContext;

        private readonly SerialDisposable _spawnDisposable = new SerialDisposable();

        private float _nextSpawnTime;

        public CompositeSpawnerController(
            SpawnSettings settings,
            ISpawnerController obstacleController,
            ISpawnerController coinController,
            ITickableContext tickableContext)
        {
            _settings = settings;
            _obstacleController = obstacleController;
            _coinController = coinController;
            _tickableContext = tickableContext;

            _disposables.Add(_spawnDisposable);
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _obstacleController.Start(token);
            await _coinController.Start(token);
            
            _spawnDisposable.Disposable = _tickableContext.Updated.Subscribe(OnSpawnUpdate);
            UpdateNextDeltaTime();
        }

        protected override async UniTask OnStopped(CancellationToken token = default)
        {
            _spawnDisposable.Disposable = default;
            
            await _obstacleController.Stop(token);
            await _coinController.Stop(token);
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
        
        private async void OnSpawnUpdate(float deltaTime)
        {
            if (!IsReadyToSpawn(deltaTime))
                return;
            
            if (IsNextCoin())
                await _coinController.Spawn();
            else
                await _obstacleController.Spawn();
            
            UpdateNextDeltaTime();
        }

        private bool IsNextCoin()
        {
            // 33% change to show coin
            int value = Random.Range(0, 3);

            return value == 0;
        }
    }
}
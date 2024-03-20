using System.Threading;
using App.Spawner.Coins.Settings;
using Cysharp.Threading.Tasks;
using Infra.Controllers.Base;
using UnityEngine;

namespace App.Spawner.Coins
{
    public class CoinSpawnerController : ControllerBase, ISpawnerController
    {
        private readonly ICoinsSettings _settings;
        private readonly SpawnPool<SpawnOptions, ISpawnView> _spawnPool;

        public CoinSpawnerController(ICoinFactory coinFactory, ICoinsSettings settings)
        {
            _settings = settings;
            _spawnPool = new SpawnPool<SpawnOptions, ISpawnView>(coinFactory);
            _disposables.Add(_spawnPool);
        }

        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _spawnPool.Reset();
            
            return base.OnStarted(token);
        }

        public UniTask Spawn(CancellationToken token = default)
        {
            int id = Random.Range(0, _settings.Items.Count);

            _spawnPool.GetObject(new SpawnOptions(id));
            
            return UniTask.CompletedTask;
        }
    }
}
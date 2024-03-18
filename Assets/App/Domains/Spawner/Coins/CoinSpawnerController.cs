using System.Threading;
using Controllers.Spawner.Coins.Factory;
using Cysharp.Threading.Tasks;
using Infra.Controllers;

namespace App.Domains.Spawner.Coins
{
    public class CoinSpawnerController : ControllerBase, ISpawnerController
    {
        private readonly ICoinFactory _coinFactory;

        public CoinSpawnerController(ICoinFactory coinFactory)
        {
            _coinFactory = coinFactory;
        }

        public UniTask Spawn(CancellationToken token = default)
        {
            return UniTask.CompletedTask;
        }
    }
}
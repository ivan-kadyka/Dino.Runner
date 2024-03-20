using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Controllers;

namespace App.Spawner
{
    public interface ISpawnerController : IController
    {
        UniTask Spawn(CancellationToken token = default);
    }
}
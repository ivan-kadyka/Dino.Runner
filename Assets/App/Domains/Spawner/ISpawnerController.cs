using System.Threading;
using Controllers;
using Cysharp.Threading.Tasks;
using Infra.Controllers;

namespace App.Domains.Spawner
{
    public interface ISpawnerController : IController
    {
        UniTask Spawn(CancellationToken token = default);
    }
}
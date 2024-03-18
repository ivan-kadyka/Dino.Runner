using System.Threading;
using Controllers;
using Cysharp.Threading.Tasks;

namespace App.Domains.Spawner
{
    public interface ISpawnerController : IController
    {
        UniTask Spawn(CancellationToken token = default);
    }
}
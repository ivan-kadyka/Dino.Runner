using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;

namespace App.Character.Dino
{
    public interface IJumpBehavior : ITickable
    {
        UniTask Execute(CancellationToken token = default);
    }
}
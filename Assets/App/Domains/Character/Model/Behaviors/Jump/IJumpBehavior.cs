using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;

namespace App.Domains.Character.Model.Behaviors.Jump
{
    public interface IJumpBehavior : ITickable
    {
        UniTask Execute(CancellationToken token = default);
    }
}
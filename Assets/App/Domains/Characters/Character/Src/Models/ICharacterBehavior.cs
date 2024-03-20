using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;

namespace App.Character
{
    public interface ICharacterBehavior : ITickable
    {
        float Speed { get; }
        
        UniTask Execute(CancellationToken token = default);
    }
}
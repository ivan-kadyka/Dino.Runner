using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Observables;

namespace Character.Model
{
    public interface ICharacterContext
    {
        CharacterState State { get; }
        
        IObservableValue<float> Speed { get; }
    }
    
    public interface ICharacter : ICharacterContext, IDisposable
    {
        UniTask Idle(CancellationToken token = default);
        
        UniTask Jump(CancellationToken token = default);

        UniTask Run(CancellationToken token = default);
    }
}
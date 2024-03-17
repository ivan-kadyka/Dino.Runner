using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Character.Model
{
    public interface ICharacter : ICharacterSpeed, IDisposable
    {
        CharacterState State { get; }

        UniTask Idle(CancellationToken token = default);
        
        UniTask Jump(CancellationToken token = default);

        UniTask Run(CancellationToken token = default);
    }

    public interface ICharacterSpeed
    {
        float Speed { get; }
    }
}
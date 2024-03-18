using System;
using System.Threading;
using App.Models;
using Cysharp.Threading.Tasks;

namespace Character.Model
{
    public interface ICharacterContext : IGameContext
    {
        CharacterState State { get; }
    }
    
    public interface ICharacter : ICharacterContext, IDisposable
    {
        UniTask Idle(CancellationToken token = default);
        
        UniTask Jump(CancellationToken token = default);

        UniTask Run(CancellationToken token = default);
    }
}
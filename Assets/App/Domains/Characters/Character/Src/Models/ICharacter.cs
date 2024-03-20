using System;
using System.Threading;
using App.GameCore;
using Cysharp.Threading.Tasks;

namespace App.Character
{
    public interface ICharacter : IGameContext, ICharacterEffectContext, IDisposable
    {
        UniTask Jump(CancellationToken token = default);

        UniTask Run(CancellationToken token = default);
        
        UniTask Idle(CancellationToken token = default);

        UniTask ApplyEffect(CharacterEffectOptions options, CancellationToken token = default);
    }
}
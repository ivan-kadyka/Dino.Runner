using System;
using System.Threading;
using App.GameCore;
using Cysharp.Threading.Tasks;

namespace App.Character
{
    public interface ICharacter : IGameContext, IDisposable
    {
        UniTask Jump(CancellationToken token = default);

        UniTask Run(CancellationToken token = default);
        
        UniTask Idle(CancellationToken token = default);

        void ChangeBehavior(ICharacterBehavior behavior);
    }
}
using System;
using System.Threading;
using App.Domains.Character.Model.Behaviors;
using App.Models;
using Cysharp.Threading.Tasks;

namespace Character.Model
{
    public interface ICharacterContext : IGameContext
    {
    }
    
    public interface ICharacter : ICharacterContext, IDisposable
    {
        UniTask Jump(CancellationToken token = default);

        UniTask Run(CancellationToken token = default);
        
        UniTask Idle(CancellationToken token = default);

        void ChangeBehavior(ICharacterBehavior behavior);
    }
}
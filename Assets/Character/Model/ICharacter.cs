using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Model
{
    public interface ICharacter
    {
        CharacterState State { get; }
        
        Vector3 Motion { get; }
        
        int Speed { get; }

        void Update();

        UniTask Idle(CancellationToken token = default);
        
        UniTask Jump(CancellationToken token = default);

        UniTask Run(CancellationToken token = default);
    }
}
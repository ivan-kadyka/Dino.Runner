using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Character.Dino
{
    internal class IdleCharacterBehavior : ICharacterBehavior
    {
        public float Speed { get; } = 0;
        public UniTask Execute(CancellationToken token = default)
        {
            return UniTask.CompletedTask;
        }

        public void Update(float deltaTime)
        {
        }
    }
}
using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Domains.Character.Model.Behaviors
{
    public class IdleCharacterBehavior : ICharacterBehavior
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
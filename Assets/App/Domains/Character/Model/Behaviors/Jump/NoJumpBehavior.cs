using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Domains.Character.Model.Behaviors.Jump
{
    public class NoJumpBehavior : IJumpBehavior
    {
        public void Update(float deltaTime)
        {
        }

        public UniTask Execute(CancellationToken token = default)
        {
            return UniTask.CompletedTask;
        }
    }
}
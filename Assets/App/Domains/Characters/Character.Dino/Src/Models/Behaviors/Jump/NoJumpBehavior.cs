using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Character.Dino
{
    internal class NoJumpBehavior : IJumpBehavior
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
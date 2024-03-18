using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Domains.Character.Model.Behaviors
{
    public class IdleCharacterBehavior : ICharacterBehavior
    {
        public bool CanExecute()
        {
            return false;
        }

        public UniTask Execute(CancellationToken token = default)
        {
            return UniTask.CompletedTask;
        }

        public void Update(float deltaTime)
        {
        }
    }
}
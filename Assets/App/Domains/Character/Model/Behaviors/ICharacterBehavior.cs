using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Domains.Character.Model.Behaviors
{
    public interface ICharacterBehavior
    {
        bool CanExecute();
        
        UniTask Execute(CancellationToken token = default);

        void Update(float deltaTime);
    }
}
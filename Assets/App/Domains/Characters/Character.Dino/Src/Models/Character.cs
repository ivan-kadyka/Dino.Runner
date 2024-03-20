using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;
using Types;
using UniRx;

namespace App.Character.Dino
{
    public class Character : DisposableBase, ICharacter
    {
        public float Speed => _behavior.Speed;
        
        private UniTaskCompletionSource _runTaskSource = new UniTaskCompletionSource();
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private readonly ICharacterPhysics _physics;
        private ICharacterBehavior _behavior = new IdleCharacterBehavior();
        
        public Character(ITickableContext tickableContext)
        {
            _disposable.Add( tickableContext.Updated.Subscribe(Update));
        }
        
        public void ChangeBehavior(ICharacterBehavior behavior)
        {
            if (behavior != null)
                _behavior = behavior;
        }

        public async UniTask Run(CancellationToken token = default)
        {
            _runTaskSource = new UniTaskCompletionSource();
            await _runTaskSource.Task;
        }

        public UniTask Idle(CancellationToken token = default)
        {
            _behavior = new IdleCharacterBehavior();
            
            _runTaskSource.TrySetResult();
            
            return UniTask.CompletedTask;
        }
        

        public async UniTask Jump(CancellationToken token = default)
        {
            await _behavior.Execute(token);
        }
        
        private void Update(float deltaTime)
        {
            _behavior.Update(deltaTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposable.Dispose();
            }
        }
    }
}
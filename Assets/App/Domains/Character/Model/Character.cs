using System.Threading;
using App.Domains.Character.Model;
using App.Domains.Character.Model.Behaviors;
using Cysharp.Threading.Tasks;
using Models.Tickable;
using Observables;
using Types;
using UniRx;
using UnityEngine;

namespace Character.Model
{
    public class Character : DisposableBase, ICharacter
    {
        public IObservableValue<float> Speed => _speedSubject;
        
        private const float _initialGameSpeed = 5f;
        private float _gameSpeedIncrease = 0.1f;
        
        private readonly ICharacterPhysics _physics;
        
        private UniTaskCompletionSource _moveTaskCompletionSource = new UniTaskCompletionSource();

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly ObservableValue<float> _speedSubject;

        private ICharacterBehavior _currentBehavior;
        
        public Character(ITickableContext tickableContext)
        {
            var settings = new CharacterSettings();
            _speedSubject = new ObservableValue<float>(settings.InitialGameSpeed);
            
            _currentBehavior = new IdleCharacterBehavior();
            
            _disposable.Add( tickableContext.Updated.Subscribe(Update));
        }
        
        public void ChangeBehavior(ICharacterBehavior behavior)
        {
            _currentBehavior = behavior;
        }

        public async UniTask Run(CancellationToken token = default)
        {
            _speedSubject.OnNext(_initialGameSpeed);
            _moveTaskCompletionSource = new UniTaskCompletionSource();
            await _moveTaskCompletionSource.Task;
        }

        public UniTask Idle(CancellationToken token = default)
        {
            _currentBehavior = new IdleCharacterBehavior();
            _speedSubject.OnNext(0);
            
            _moveTaskCompletionSource.TrySetResult();
            
            return UniTask.CompletedTask;
        }
        

        public async UniTask Jump(CancellationToken token = default)
        {
            if (_currentBehavior.CanExecute())
                await _currentBehavior.Execute(token);
        }
        
        private void Update(float deltaTime)
        {
            float nextSpeed = _speedSubject.Value;
            nextSpeed += _gameSpeedIncrease * Time.deltaTime;
            _speedSubject.OnNext(nextSpeed);
            
            _currentBehavior.Update(deltaTime);
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
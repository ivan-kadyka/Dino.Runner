using System.Threading;
using App.Domains.Character.Model;
using App.Domains.Character.Model.Behaviors;
using Cysharp.Threading.Tasks;
using Observables;
using Types;
using UniRx;
using UnityEngine;

namespace Character.Model
{
    public class Character : DisposableBase, ICharacter
    {
        public IObservableValue<float> Speed => _speedSubject;

        private CharacterState _state;
        
        private float _initialGameSpeed = 5f;
        private float _gameSpeedIncrease = 0.1f;
        
        private readonly ICharacterPhysics _physics;
        
        private UniTaskCompletionSource _moveTaskCompletionSource = new UniTaskCompletionSource();

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly ObservableValue<float> _speedSubject = new ObservableValue<float>(0);

        private ICharacterBehavior _currentBehavior;
        private readonly ICharacterBehavior _defaultBehavior;
        private readonly ICharacterBehavior _flyBehavior;
        
        public Character(ICharacterPhysics physics)
        {
            _physics = physics;
            _disposable.Add( _physics.Updated.Subscribe(Update));
            _disposable.Add( _physics.Collider.Subscribe(OnCollider));

            var settings = new CharacterSettings();
            
            _defaultBehavior = new DefaultCharacterBehavior(physics, settings);
            _flyBehavior = new FlyCharacterBehavior(physics, settings);
            
            _currentBehavior = _defaultBehavior;
        }

        public UniTask Idle(CancellationToken token = default)
        {
            _state = CharacterState.Idle;
            _currentBehavior = new IdleCharacterBehavior();
            _speedSubject.OnNext(0);
            
            _moveTaskCompletionSource.TrySetResult();
            
            return UniTask.CompletedTask;
        }

        public async UniTask Run(CancellationToken token = default)
        {
            _state = CharacterState.Run;
            _currentBehavior = _defaultBehavior;
            
            _speedSubject.OnNext(_initialGameSpeed);
            _moveTaskCompletionSource = new UniTaskCompletionSource();
            await _moveTaskCompletionSource.Task;
        }

        public async UniTask Jump(CancellationToken token = default)
        {
            if (_state != CharacterState.Idle && _currentBehavior.CanExecute())
                await _currentBehavior.Execute(token);
        }
        
        private void Update(float deltaTime)
        {
            if (_state == CharacterState.Idle)
                return;

            float nextSpeed = _speedSubject.Value;
            nextSpeed += _gameSpeedIncrease * Time.deltaTime;
            _speedSubject.OnNext(nextSpeed);
            
            _currentBehavior.Update(deltaTime);
        }

        private async void OnCollider(string objectTag)
        {
            if (objectTag == "Obstacle")
            {
               await Idle();
            }
            
            else if (objectTag == "Coin")
            {
                _currentBehavior = _flyBehavior;
                Debug.Log("Coin collider");
            }
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
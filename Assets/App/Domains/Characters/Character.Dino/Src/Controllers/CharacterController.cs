using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;
using Infra.Controllers.Base;
using Infra.Observable;
using Infra.Observable.UniRx;
using UniRx;

namespace App.Character.Dino
{
    public class CharacterController : ControllerBase, ICharacterBehaviorContext
    {
        public IObservableValue<CharacterBehaviorType> CurrentType => _behaviorTypeSubject;
        public IObservable<TimeSpan> TimeLeft => _timeSubject;
        
        private readonly ICharacter _character;
        private readonly ICharacterPhysics _physics;
        private readonly ITickableContext _tickableContext;
        private readonly ICharacterBehaviorFactory _behaviorFactory;

        private ICharacterBehavior _defaultBehavior;

        private readonly ObservableValue<CharacterBehaviorType> _behaviorTypeSubject = new ObservableValue<CharacterBehaviorType>(CharacterBehaviorType.Default);
        private readonly ObservableValue<TimeSpan> _timeSubject = new ObservableValue<TimeSpan>(TimeSpan.Zero);

        private readonly SerialDisposable _timerDisposable = new SerialDisposable();
        
        public CharacterController(
            ICharacter character,
            ICharacterPhysics physics, 
            IInputCharacterController inputCharacterController,
            ITickableContext tickableContext,
            ICharacterBehaviorFactory behaviorFactory)
        {
            _character = character;
            _physics = physics;
            _tickableContext = tickableContext;
            _behaviorFactory = behaviorFactory;
            
            _disposables.Add(physics.Collider.Subscribe(OnCollider));
            _disposables.Add(inputCharacterController.JumpPressed.Subscribe(OnJumpPressed));
            _disposables.Add(_timerDisposable);
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            _defaultBehavior = _behaviorFactory.Create(CharacterBehaviorType.Default);
            _character.ChangeBehavior(_defaultBehavior);
            _behaviorTypeSubject.OnNext(CharacterBehaviorType.Default);
            await _character.Run(token);
        }

        protected override UniTask OnStopped(CancellationToken token = default)
        {
            _timerDisposable.Disposable = default;
            return base.OnStopped(token);
        }

        private async void OnCollider(string objectName)
        {
            switch (objectName)
            {
                case "Obstacle":
                    _physics.Play(CharacterSoundType.Die);
                    await _character.Idle();
                    break;
                case "Coin_Fly":
                    ChangeBehaviour(CharacterBehaviorType.Fly);
                    break;
                case "Coin_Slow":
                    ChangeBehaviour(CharacterBehaviorType.Slow);
                    break;
                case "Coin_Fast":
                    ChangeBehaviour(CharacterBehaviorType.Fast);
                    break;
            }
        }

        private void ChangeBehaviour(CharacterBehaviorType type)
        {
            _physics.Play(CharacterSoundType.Coin);
            var newBehavior = _behaviorFactory.Create(type);
                  
            _character.ChangeBehavior(newBehavior);
            _timerDisposable.Disposable = _tickableContext.Updated.Subscribe(OnEffectTimer);
                    
            _behaviorTypeSubject.OnNext(type);
            _timeSubject.OnNext(TimeSpan.FromMilliseconds(10000));
        }

        private void OnEffectTimer(float deltaTime)
        {
            var timeLeft = _timeSubject.Value - TimeSpan.FromMilliseconds(deltaTime * 1000);

            if (timeLeft.TotalMilliseconds > 0)
            {
                _timeSubject.OnNext(timeLeft);
            }
            else
            {
                _timerDisposable.Disposable = default;
                _character.ChangeBehavior(_defaultBehavior);
                _behaviorTypeSubject.OnNext(CharacterBehaviorType.Default);
            }
        }

        private async void OnJumpPressed(Unit unit)
        {
            await _character.Jump();
        }
    }
}
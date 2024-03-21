using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;
using Infra.Observable;
using Infra.Observable.UniRx;
using Types;
using UniRx;

namespace App.Character.Dino
{
    internal class Character : DisposableBase, ICharacter
    {
        public IObservableValue<CharacterEffect> Effect => _behaviorTypeSubject;
        public IObservable<TimeSpan> TimeLeft => _timeSubject;
        
        public float Speed => _currentBehavior.Speed;
        
        private UniTaskCompletionSource _runTaskSource = new UniTaskCompletionSource();
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        
        private readonly ICharacterSounds _sounds;

        private readonly ITickableContext _tickableContext;
        private readonly ICharacterBehaviorFactory _behaviorFactory;

        private ICharacterBehavior _defaultBehavior;
        private ICharacterBehavior _currentBehavior = new IdleCharacterBehavior();

        private readonly ObservableValue<CharacterEffect> _behaviorTypeSubject = new ObservableValue<CharacterEffect>(CharacterEffect.Default);
        private readonly ObservableValue<TimeSpan> _timeSubject = new ObservableValue<TimeSpan>(TimeSpan.Zero);
        private readonly SerialDisposable _timerDisposable = new SerialDisposable();
        
        public Character(
            ICharacterSounds sounds,
            ITickableContext tickableContext,
            ICharacterBehaviorFactory behaviorFactory)
        {
            _sounds = sounds;
            _behaviorFactory = behaviorFactory;
            _tickableContext = tickableContext;
            
            _disposables.Add( tickableContext.Updated.Subscribe(Update));
            _disposables.Add(_timerDisposable);
        }

        private void ChangeBehavior(ICharacterBehavior behavior, CharacterEffect effect)
        {
            if (_currentBehavior == behavior) 
                return;
            
            _currentBehavior = behavior;
            _behaviorTypeSubject.OnNext(effect);
        }

        public async UniTask Run(CancellationToken token = default)
        {
            _defaultBehavior = _behaviorFactory.Create(CharacterBehaviorOptions.Default);
            ChangeBehavior(_defaultBehavior, CharacterEffect.Default);
            
            _runTaskSource = new UniTaskCompletionSource();
           // _disposables.Add(token.Register(()=> _runTaskSource.TrySetCanceled()));
            
            await _runTaskSource.Task;
        }

        public async UniTask Idle(CancellationToken token = default)
        {
            _timerDisposable.Disposable = default;
            ChangeBehavior(new IdleCharacterBehavior(), CharacterEffect.Idle);
            
            _sounds.Play(CharacterSoundType.Idle);
            _runTaskSource.TrySetResult();
            
            await _currentBehavior.Execute(token);
        }

        public UniTask ApplyEffect(CharacterEffectOptions options, CancellationToken token = default)
        {
            _sounds.Play(CharacterSoundType.Effect);
            
            var newBehavior = _behaviorFactory.Create(new CharacterBehaviorOptions(options.Type, _currentBehavior.Speed));
                  
            ChangeBehavior(newBehavior, options.Type);
            
            _timerDisposable.Disposable = _tickableContext.Updated.Subscribe(OnEffectTimer);
            _timeSubject.OnNext(options.Duration);

            return UniTask.CompletedTask;
        }
        

        public async UniTask Jump(CancellationToken token = default)
        {
            await _currentBehavior.Execute(token);
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
                ChangeBehavior(_defaultBehavior, CharacterEffect.Default);
            }
        }
        
        private void Update(float deltaTime)
        {
            _currentBehavior.Update(deltaTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _runTaskSource.TrySetCanceled();
                _disposables.Dispose();
            }
        }
    }
}
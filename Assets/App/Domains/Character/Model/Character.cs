using System.Threading;
using Cysharp.Threading.Tasks;
using Observables;
using Types;
using UniRx;
using UnityEngine;

namespace Character.Model
{
    public class Character : DisposableBase, ICharacter
    {
        public CharacterState State => _state;

        public IObservableValue<float> Speed => _speedSubject;

        private CharacterState _state;
        private Vector3 _motion;

        private const float jumpForce = 8f;
        private const float gravity = 9.81f * 2f;
        
        private float _initialGameSpeed = 5f;
        private float _gameSpeedIncrease = 0.1f;
        
        private readonly ICharacterPhysics _physics;
        
        private UniTaskCompletionSource _jumpingTaskCompletionSource = new UniTaskCompletionSource();
        private UniTaskCompletionSource _moveTaskCompletionSource = new UniTaskCompletionSource();

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly ObservableValue<float> _speedSubject = new ObservableValue<float>(0);
        
        public Character(ICharacterPhysics physics)
        {
            _physics = physics;
            _disposable.Add( _physics.Updated.Subscribe(Update));
            _disposable.Add( _physics.Collider.Subscribe(OnCollider));
        }

        public UniTask Idle(CancellationToken token = default)
        {
            _motion = Vector3.zero;
            _state = CharacterState.Idle;
            _speedSubject.OnNext(0);
            
            _moveTaskCompletionSource.TrySetResult();
            
            return UniTask.CompletedTask;
        }

        public async UniTask Run(CancellationToken token = default)
        {
            _state = CharacterState.Run;
            
            _speedSubject.OnNext(_initialGameSpeed);
            _moveTaskCompletionSource = new UniTaskCompletionSource();
            await _moveTaskCompletionSource.Task;
        }

        public UniTask Jump(CancellationToken token = default)
        {
            if (!CanJump())
                return UniTask.CompletedTask;
            
            _jumpingTaskCompletionSource.TrySetResult();
            _jumpingTaskCompletionSource = new UniTaskCompletionSource();
            
            if (_state == CharacterState.Run)
                _state = CharacterState.Jumping;
            
            _motion = Vector3.up * jumpForce;

            ExecuteJumping();

            return _jumpingTaskCompletionSource.Task;
        }

        private bool CanJump()
        {
            return _state == CharacterState.Run || _state == CharacterState.Fly;
        }

        private void ExecuteJumping()
        {
            // Apply gravity to the motion
            _motion += gravity * Time.deltaTime * Vector3.down;
    
            // Calculate the potential new position without actually moving the character
            Vector3 potentialPosition = _physics.Transform.position + (_motion * Time.deltaTime);

            // Check if the potential new position exceeds the maximum allowed height
            if (potentialPosition.y > 5f)
            {
                // If it does, adjust the _motion vector so that the final position will exactly be at the height limit
                float deltaY = 5f - _physics.Transform.position.y; // Difference between current height and maximum allowed height
                _motion = (deltaY / Time.deltaTime) * Vector3.up; // Adjust _motion so after the movement, the character ends up 
            }

            // Apply the movement
            _physics.Move(_motion * Time.deltaTime);
        }
        
        private void Update(float deltaTime)
        {
            if (_state == CharacterState.Idle)
                return;

            float nextSpeed = _speedSubject.Value;
            nextSpeed += _gameSpeedIncrease * Time.deltaTime;
            _speedSubject.OnNext(nextSpeed);
            
            switch (_state)
            {
                case CharacterState.Fly:
                    ExecuteJumping();
                    break;
                case CharacterState.Jumping:
                    if (_physics.IsGrounded)
                    {
                        _jumpingTaskCompletionSource.TrySetResult();
                        _state = CharacterState.Run;
                    }
                    else
                    {
                        ExecuteJumping();
                    }
                       
                    break;
            }
        }

        private async void OnCollider(string objectTag)
        {
            if (objectTag == "Obstacle")
            {
               await Idle();
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
using System.Threading;
using Cysharp.Threading.Tasks;
using Types;
using UniRx;
using UnityEngine;
using Unit = Types.Unit;

namespace Character.Model
{
    public class Character : DisposableBase, ICharacter
    {
        private readonly ICharacterPhysics _physics;
        public CharacterState State => _state;

        private CharacterState _state;
        private Vector3 _motion;

        private float jumpForce = 8f;
        private float gravity = 9.81f * 2f;
        
        private UniTaskCompletionSource _jumpingTaskCompletionSource = new UniTaskCompletionSource();
        private UniTaskCompletionSource _moveTaskCompletionSource = new UniTaskCompletionSource();

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        
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
            _moveTaskCompletionSource.TrySetResult();
            
            return UniTask.CompletedTask;
        }

        public async UniTask Run(CancellationToken token = default)
        {
            _state = CharacterState.Run;
            _moveTaskCompletionSource = new UniTaskCompletionSource();
            await _moveTaskCompletionSource.Task;
        }

        public UniTask Jump(CancellationToken token = default)
        {
            if (_state != CharacterState.Run)
                return UniTask.CompletedTask;

            _jumpingTaskCompletionSource = new UniTaskCompletionSource();

            _state = CharacterState.Jumping;
            _motion = Vector3.up * jumpForce;

            ExecuteJumping();

            return _jumpingTaskCompletionSource.Task;
        }

        private void ExecuteJumping()
        {
            _motion += gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);
        }
        
        private void Update(Unit unit)
        {
            switch (_state)
            {
                case CharacterState.Idle:
                    return;
                
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
            if (objectTag == "Obstacle") {
                GameManager.Instance.GameOver();
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
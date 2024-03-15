using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.View
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        private CharacterController _character;
        
        private Vector3 _direction;

        public float jumpForce = 8f;
        public float gravity = 9.81f * 2f;

        private CharacterState _state;
        private UniTaskCompletionSource _jumpingTaskCompletionSource = new UniTaskCompletionSource();
        private UniTaskCompletionSource _moveTaskCompletionSource = new UniTaskCompletionSource();

        private void Awake()
        {
            _character = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _direction = Vector3.zero;
            _moveTaskCompletionSource = new UniTaskCompletionSource();
        }

        private void Update()
        {
            switch (_state)
            {
                case  CharacterState.Jumping:
                    if (_character.isGrounded)
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle")) {
                GameManager.Instance.GameOver();
                _moveTaskCompletionSource.TrySetResult();
            }
        }

        public async UniTask Move(CancellationToken token = default)
        {
            _moveTaskCompletionSource = new UniTaskCompletionSource();
            await _moveTaskCompletionSource.Task;
        }

        public UniTask Jump(CancellationToken token = default)
        {
            if (_state == CharacterState.Jumping)
                return UniTask.CompletedTask;

            _jumpingTaskCompletionSource = new UniTaskCompletionSource();

            _state = CharacterState.Jumping;
            _direction = Vector3.up * jumpForce;

            ExecuteJumping();

            return _jumpingTaskCompletionSource.Task;
        }

        private void ExecuteJumping()
        {
            _direction += gravity * Time.deltaTime * Vector3.down;
            _character.Move(_direction * Time.deltaTime);
        }

        enum CharacterState
        {
           Run,
           Jumping
        }
    }
}
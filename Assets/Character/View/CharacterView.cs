using Character.Model;
using UnityEngine;

namespace Character.View
{
    public class CharacterView : MonoBehaviour, ICharacterView, ICharacterPhysics
    {
        public bool IsGrounded => _characterComponentController.isGrounded;

        private CharacterController _characterComponentController;
        private ICharacter _character;

        public void Initialize(ICharacter character)
        {
            _character = character;
        }

        private void Awake()
        {
            _characterComponentController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_character != null)
            {
                _character.Update();
            }
        }
        
        public void Move(Vector3 motion)
        {
            _characterComponentController.Move(motion);
        }

        private async void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle")) {
                GameManager.Instance.GameOver();
                await _character.Idle();
            }
        }

        public void Dispose()
        {
          //  Destroy(gameObject);
        }
    }
}
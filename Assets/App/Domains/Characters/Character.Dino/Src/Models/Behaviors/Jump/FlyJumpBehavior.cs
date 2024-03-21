using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Character.Dino
{
    internal class FlyJumpBehavior : IJumpBehavior
    {
        private readonly ICharacterPhysics _physics;
        private readonly ICharacterSounds _sounds;
        private readonly CharacterSettings _settings;
        
        private Vector3 _motion;

        public FlyJumpBehavior(
            ICharacterPhysics physics,
            ICharacterSounds sounds,
            CharacterSettings settings)
        {
            _physics = physics;
            _sounds = sounds;
            _settings = settings;
        }

        public void Update(float deltaTime)
        {
            if (_physics.IsGrounded)
                return;

            ExecuteJumping();
        }

        public UniTask Execute(CancellationToken token = default)
        {
            _sounds.Play(CharacterSoundType.Jump);
            _motion = Vector3.up * _settings.JumpForce;
            ExecuteJumping();

            return UniTask.CompletedTask;
        }
        
        private void ExecuteJumping()
        {
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            Vector3 potentialPosition = _physics.Transform.position + (_motion * Time.deltaTime);

            //TODO: 5f - hardcoded value. better way is handling collider by others game object
            // Check if the potential new position exceeds the maximum allowed height
            if (potentialPosition.y > 5f)
            {
                // If it does, adjust the _motion vector so that the final position will exactly be at the height limit
                float deltaY = 5f - _physics.Transform.position.y; // Difference between current height and maximum allowed height
                _motion = (deltaY / Time.deltaTime) * Vector3.up; // Adjust _motion so after the movement, the character ends up 
            }
            
            _physics.Move(_motion * Time.deltaTime);
        }
    }
}
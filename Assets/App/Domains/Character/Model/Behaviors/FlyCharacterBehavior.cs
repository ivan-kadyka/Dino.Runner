using System.Threading;
using Character.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Domains.Character.Model.Behaviors
{
    public class FlyCharacterBehavior : ICharacterBehavior
    {
        public float Speed { get; }
        
        private readonly ICharacterPhysics _physics;
        private readonly CharacterSettings _settings;
        private Vector3 _motion;
        
        public FlyCharacterBehavior(ICharacterPhysics physics, CharacterSettings settings)
        {
            _physics = physics;
            _settings = settings;
            Speed = 5;
        }
        
        public void Update(float deltaTime)
        {
            if (_physics.IsGrounded)
                return;

            ExecuteJumping();
        }

        public UniTask Execute(CancellationToken token = default)
        {
            _motion = Vector3.up * _settings.JumpForce;
            ExecuteJumping();

            return UniTask.CompletedTask;
        }
        
        private void ExecuteJumping()
        {
            // Apply gravity to the motion
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
    
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
    }
}
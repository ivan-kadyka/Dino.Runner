using System.Threading;
using Character.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace App.Domains.Character.Model.Behaviors.Jump
{
    public class JumpBehavior : IJumpBehavior
    {
        private readonly ICharacterPhysics _physics;
        private readonly CharacterSettings _settings;
        
        private Vector3 _motion;

        public JumpBehavior(ICharacterPhysics physics, CharacterSettings settings)
        {
            _physics = physics;
            _settings = settings;
        }
        
        public void Update(float deltaTime)
        {
            if (_physics.IsGrounded)
                return;
            
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);
        }

        public UniTask Execute(CancellationToken token = default)
        {
            if (_physics.IsGrounded)
            {
                _motion = Vector3.up * _settings.JumpForce;
                _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
                _physics.Move(_motion * Time.deltaTime);
            }

            return UniTask.CompletedTask;
        }
    }
}
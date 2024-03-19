using System.Threading;
using Character.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Domains.Character.Model.Behaviors
{
    public class DefaultCharacterBehavior : ICharacterBehavior
    {
        public float Speed => _speed;
        
        private readonly ICharacterPhysics _physics;
        private readonly CharacterSettings _settings;
        private Vector3 _motion;

        private float _speed;

        public DefaultCharacterBehavior(ICharacterPhysics physics, CharacterSettings settings)
        {
            _physics = physics;
            _settings = settings;
            _speed = settings.InitialGameSpeed;
        }

        public void Update(float deltaTime)
        {
            _speed += _settings.GameSpeedIncrease * Time.deltaTime;
            
            if (_physics.IsGrounded)
                return;
            
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);
        }

        public UniTask Execute(CancellationToken token = default)
        {
            _motion = Vector3.up * _settings.JumpForce;
            
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);

            return UniTask.CompletedTask;
        }
    }
}
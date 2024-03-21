using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace App.Character.Dino
{
    internal class JumpBehavior : IJumpBehavior
    {
        private readonly ICharacterPhysics _physics;
        private readonly ICharacterSounds _sounds;
        private readonly CharacterSettings _settings;
        
        private Vector3 _motion;

        public JumpBehavior(
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
            
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);
        }

        public UniTask Execute(CancellationToken token = default)
        {
            if (_physics.IsGrounded)
            {
                _sounds.Play(CharacterSoundType.Jump);
                
                _motion = Vector3.up * _settings.JumpForce;
                _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
                _physics.Move(_motion * Time.deltaTime);
            }

            return UniTask.CompletedTask;
        }
    }
}
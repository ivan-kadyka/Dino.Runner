using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Character.Dino
{
    internal class DefaultCharacterBehavior : ICharacterBehavior
    {
        public float Speed => _speed;
        
        private readonly ICharacterPhysics _physics;
        private readonly IJumpBehavior _jumpBehavior;
        private readonly CharacterSettings _settings;
        private Vector3 _motion;

        private float _speed;

        public DefaultCharacterBehavior(IJumpBehavior jumpBehavior, CharacterSettings settings)
        {
            _jumpBehavior = jumpBehavior;
            _settings = settings;
            _speed = settings.InitialGameSpeed;
        }

        public void Update(float deltaTime)
        {
            _speed += _settings.GameSpeedIncrease * Time.deltaTime;
            
            _jumpBehavior.Update(deltaTime);
        }

        public UniTask Execute(CancellationToken token = default)
        {
            return _jumpBehavior.Execute(token);
        }
    }
}
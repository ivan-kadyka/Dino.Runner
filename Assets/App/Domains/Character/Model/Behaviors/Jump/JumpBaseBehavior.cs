using System.Threading;
using Character.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Domains.Character.Model.Behaviors.Jump
{
    public abstract class JumpBaseBehavior : IJumpBehavior
    {
        protected readonly ICharacterPhysics _physics;
        protected readonly CharacterSettings _settings;
        protected Vector3 _motion;
        
        protected JumpBaseBehavior(ICharacterPhysics physics, CharacterSettings settings)
        {
            _physics = physics;
            _settings = settings;
        }
        
        public virtual void Update(float deltaTime)
        {
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);
        }

        public virtual UniTask Execute(CancellationToken token = default)
        {
            _motion = Vector3.up * _settings.JumpForce;
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);

            return UniTask.CompletedTask;
        }
    }
}
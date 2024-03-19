using System;
using Character.Model;

namespace App.Domains.Character.Model.Behaviors.Jump.Factory
{
    public class JumpBehaviorFactory : IJumpBehaviorFactory
    {
        private readonly ICharacterPhysics _physics;
        private readonly CharacterSettings _settings;

        public JumpBehaviorFactory(ICharacterPhysics physics, CharacterSettings settings)
        {
            _physics = physics;
            _settings = settings;
        }
        
        public IJumpBehavior Create(JumpBehaviorType type)
        {
            switch (type)
            {
                case JumpBehaviorType.Default:
                    return new JumpBehavior(_physics, _settings);
                case JumpBehaviorType.Fly:
                    return new FlyJumpBehavior(_physics, _settings);
                case JumpBehaviorType.NoJump:
                    return new NoJumpBehavior();
                default:
                    throw new InvalidOperationException($"Can't create selected '{type}' jump behavior");
            }
        }
    }
}
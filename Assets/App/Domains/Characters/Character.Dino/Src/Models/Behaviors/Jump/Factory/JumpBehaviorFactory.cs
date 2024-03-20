using System;

namespace App.Character.Dino
{
    public class JumpBehaviorFactory : IJumpBehaviorFactory
    {
        private readonly ICharacterPhysics _physics;
        private readonly ICharacterSounds _sounds;
        private readonly CharacterSettings _settings;

        public JumpBehaviorFactory(
            ICharacterPhysics physics,
            ICharacterSounds sounds,
            CharacterSettings settings)
        {
            _physics = physics;
            _sounds = sounds;
            _settings = settings;
        }
        
        public IJumpBehavior Create(JumpBehaviorType type)
        {
            switch (type)
            {
                case JumpBehaviorType.Default:
                    return new JumpBehavior(_physics, _sounds, _settings);
                case JumpBehaviorType.Fly:
                    return new FlyJumpBehavior(_physics, _sounds, _settings);
                case JumpBehaviorType.NoJump:
                    return new NoJumpBehavior();
                default:
                    throw new InvalidOperationException($"Can't create selected '{type}' jump behavior");
            }
        }
    }
}
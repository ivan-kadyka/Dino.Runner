using System;

namespace App.Character.Dino
{
    internal class CharacterBehaviorFactory : ICharacterBehaviorFactory
    {
        private readonly IJumpBehaviorFactory _jumpBehaviorFactory;
        private readonly CharacterSettings _settings;

        public CharacterBehaviorFactory(IJumpBehaviorFactory jumpBehaviorFactory, CharacterSettings settings)
        {
            _jumpBehaviorFactory = jumpBehaviorFactory;
            _settings = settings;
        }
        
        public ICharacterBehavior Create(CharacterBehaviorOptions options)
        {
            switch (options.State)
            {
                case CharacterState.Default:
                {
                    var jumpBehavior = _jumpBehaviorFactory.Create(JumpBehaviorType.Default);
                    return new DefaultCharacterBehavior(jumpBehavior, _settings);
                }
                case CharacterState.Idle:
                {
                    return new IdleCharacterBehavior();
                }
                case CharacterState.Fly:
                {
                    var jumpBehavior = _jumpBehaviorFactory.Create(JumpBehaviorType.Fly);
                    return new CharacterBehavior(jumpBehavior, options.Speed);
                }
                case CharacterState.Fast:
                {
                    return CreateSpeedBehavior(options.Speed * 1.5f);
                }
                case CharacterState.Slow:
                {
                    return CreateSpeedBehavior(options.Speed / 1.5f);
                }
                default:
                    throw new InvalidOperationException($"Can't create selected '{options.State}' character behavior type");
            }
        }

        private ICharacterBehavior CreateSpeedBehavior(float speed)
        {
            var jumpBehavior = _jumpBehaviorFactory.Create(JumpBehaviorType.Default);
            return new CharacterBehavior(jumpBehavior, speed);
        }
    }
}
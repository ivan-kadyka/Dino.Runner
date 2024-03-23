using System;
using App.GameCore;

namespace App.Character.Dino
{
    internal class CharacterBehaviorFactory : ICharacterBehaviorFactory
    {
        private readonly IJumpBehaviorFactory _jumpBehaviorFactory;
        private readonly CharacterSettings _settings;
        private readonly IGameContext _gameContext;

        public CharacterBehaviorFactory(
            IJumpBehaviorFactory jumpBehaviorFactory,
            CharacterSettings settings,
            IGameContext gameContext)
        {
            _jumpBehaviorFactory = jumpBehaviorFactory;
            _settings = settings;
            _gameContext = gameContext;
        }
        
        public ICharacterBehavior Create(CharacterState type)
        {
            switch (type)
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
                    return new CharacterBehavior(jumpBehavior, _gameContext.Speed);
                }
                case CharacterState.Fast:
                {
                    return CreateSpeedBehavior(_gameContext.Speed * 1.5f);
                }
                case CharacterState.Slow:
                {
                    return CreateSpeedBehavior(_gameContext.Speed / 1.5f);
                }
                default:
                    throw new InvalidOperationException($"Can't create selected '{type}' character behavior type");
            }
        }

        private ICharacterBehavior CreateSpeedBehavior(float speed)
        {
            var jumpBehavior = _jumpBehaviorFactory.Create(JumpBehaviorType.Default);
            return new CharacterBehavior(jumpBehavior, speed);
        }
    }
}
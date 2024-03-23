using System;
using System.Threading;
using App.GameCore;
using App.GameCore.Obstacle;
using Cysharp.Threading.Tasks;
using Infra.Controllers.Base;
using UniRx;

namespace App.Character.Dino
{
    internal class CharacterController : ControllerBase
    {
        private readonly ICharacter _character;
        private readonly ICharacterBehaviorFactory _behaviorFactory;

        public CharacterController(
            ICharacter character,
            ICharacterPhysics physics, 
            ICharacterBehaviorFactory behaviorFactory,
            IInputCharacterController inputCharacterController)
        {
            _character = character;
            _behaviorFactory = behaviorFactory;

            _disposables.Add(inputCharacterController.JumpPressed.Subscribe(OnJumpPressed));
            _disposables.Add(physics.Collider.Subscribe(OnCollider));
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _character.Run(token);
        }

        private async void OnCollider(IObject colliderObject)
        {
            switch (colliderObject)
            {
                case ObstacleObject:
                    await _character.Idle();
                    break;
                case CoinObject coinObject:
                    await CoinEffectBehaviorStrategy(coinObject.CoinType);
                    break;
            }
        }

        private async UniTask CoinEffectBehaviorStrategy(CoinType coinType)
        {
            EffectOptions options = default;
            
            switch (coinType)
            {
                case CoinType.Fly:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    options = new EffectOptions(CharacterEffect.Fly, duration);
                    break;  
                }
                case CoinType.Slow:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    options = new EffectOptions(CharacterEffect.Slow, duration);
                    break;
                }
                case CoinType.Fast:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    options = new EffectOptions(CharacterEffect.Fast, duration);
                    break;
                }
            }

            if (options != null)
            {
                var newBehavior = _behaviorFactory.Create(options.Type);
                await _character.ApplyEffectBehavior(newBehavior, options);
            }
        }
        
        private async void OnJumpPressed(Unit unit)
        {
            await _character.Jump();
        }
    }
}
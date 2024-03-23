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
                    await CoinHandleStrategy(coinObject.CoinType);
                    break;
            }
        }

        private async UniTask CoinHandleStrategy(CoinType coinType)
        {
            EffectStartOptions startOptions = default;
            
            switch (coinType)
            {
                case CoinType.Fly:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    startOptions = new EffectStartOptions(CharacterState.Fly, duration);
                    break;  
                }
                case CoinType.Slow:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    startOptions = new EffectStartOptions(CharacterState.Slow, duration);
                    break;
                }
                case CoinType.Fast:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    startOptions = new EffectStartOptions(CharacterState.Fast, duration);
                    break;
                }
            }

            if (startOptions != null)
            {
                var newBehavior = _behaviorFactory.Create(new CharacterBehaviorOptions(startOptions.Type, _character.Speed));
                await _character.ApplyEffectBehavior(newBehavior, startOptions);
            }
        }
        
        private async void OnJumpPressed(Unit unit)
        {
            await _character.Jump();
        }
    }
}
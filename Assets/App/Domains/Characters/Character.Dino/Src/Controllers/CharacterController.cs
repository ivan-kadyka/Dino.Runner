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

        public CharacterController(
            ICharacter character,
            ICharacterPhysics physics, 
            IInputCharacterController inputCharacterController)
        {
            _character = character;
            
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
            switch (coinType)
            {
                case CoinType.Fly:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    var options = new CharacterOptions(CharacterState.Fly, duration);
                    await _character.ApplyEffect(options);
                    break;  
                }
                case CoinType.Slow:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    var options = new CharacterOptions(CharacterState.Slow, duration);
                    await _character.ApplyEffect(options);
                    break;
                }
                case CoinType.Fast:
                {
                    var duration = TimeSpan.FromSeconds(10);
                    var options = new CharacterOptions(CharacterState.Fast, duration);
                    await _character.ApplyEffect(options);
                    break;
                }
            }
        }
        
        private async void OnJumpPressed(Unit unit)
        {
            await _character.Jump();
        }
    }
}
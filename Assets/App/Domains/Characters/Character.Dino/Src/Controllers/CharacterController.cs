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
            IInputCharacterController inputCharacterController,
            IColliderObjectObservable colliderObjectObservable)
        {
            _character = character;

           // _disposables.Add(physics.Collider.Subscribe(OnCollider));
            _disposables.Add(inputCharacterController.JumpPressed.Subscribe(OnJumpPressed));
            _disposables.Add(colliderObjectObservable.Subscribe(OnCollider));
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
                    await CoinsHandlingStrategy(coinObject.CoinType);
                    break;
            }
        }

        private async UniTask CoinsHandlingStrategy(CoinType coinType)
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
        

        private async void OnCollider(string objectName)
        {
            switch (objectName)
            {
                case "Obstacle":
                    await _character.Idle();
                    break;
                case "Coin_Fly":
                {
                    var options = new CharacterOptions(CharacterState.Fly, TimeSpan.FromSeconds(10));
                    await _character.ApplyEffect(options);
                    break;  
                }
                case "Coin_Slow":
                {
                    var options = new CharacterOptions(CharacterState.Slow, TimeSpan.FromSeconds(10));
                    await _character.ApplyEffect(options);
                    break;
                }
                case "Coin_Fast":
                {
                    var options = new CharacterOptions(CharacterState.Fast, TimeSpan.FromSeconds(10));
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
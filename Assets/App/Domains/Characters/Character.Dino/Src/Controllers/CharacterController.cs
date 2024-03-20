using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Controllers.Base;
using UniRx;

namespace App.Character.Dino
{
    public class CharacterController : ControllerBase
    {
        private readonly ICharacter _character;
        
        public CharacterController(
            ICharacter character,
            ICharacterPhysics physics, 
            IInputCharacterController inputCharacterController)
        {
            _character = character;
            
            _disposables.Add(physics.Collider.Subscribe(OnCollider));
            _disposables.Add(inputCharacterController.JumpPressed.Subscribe(OnJumpPressed));
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _character.Run(token);
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
                    var options = new CharacterEffectOptions(CharacterEffect.Fly, TimeSpan.FromSeconds(10));
                    await _character.ApplyEffect(options);
                    break;  
                }
                case "Coin_Slow":
                {
                    var options = new CharacterEffectOptions(CharacterEffect.Slow, TimeSpan.FromSeconds(10));
                    await _character.ApplyEffect(options);
                    break;
                }
                case "Coin_Fast":
                {
                    var options = new CharacterEffectOptions(CharacterEffect.Fast, TimeSpan.FromSeconds(10));
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
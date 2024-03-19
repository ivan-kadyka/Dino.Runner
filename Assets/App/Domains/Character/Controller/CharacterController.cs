using System.Threading;
using App.Domains.Character.Controller.Inputs;
using App.Domains.Character.Model;
using App.Domains.Character.Model.Behaviors;
using App.Domains.Character.Model.Behaviors.Factory;
using Character.Model;
using Cysharp.Threading.Tasks;
using Infra.Controllers;
using UniRx;

namespace Character.Controller
{
    public class CharacterController : ControllerBase
    {
        private readonly ICharacter _character;
        private readonly ICharacterBehaviorFactory _behaviorFactory;

        private ICharacterBehavior _defaultBehavior;
        public CharacterController(
            ICharacter character,
            ICharacterPhysics physics, 
            IInputCharacterController inputCharacterController,
            ICharacterBehaviorFactory behaviorFactory)
        {
            _character = character;
            _behaviorFactory = behaviorFactory;
            
            _disposables.Add(physics.Collider.Subscribe(OnCollider));
            _disposables.Add(inputCharacterController.JumpPressed.Subscribe(OnJumpPressed));
        }

        private async void OnCollider(string objectTag)
        {
            switch (objectTag)
            {
                case "Obstacle":
                    await _character.Idle();
                    break;
                case "Coin_Fly":
                {
                    var newBehavior = _behaviorFactory.Create(CharacterBehaviorType.Fly);
                    _character.ChangeBehavior(newBehavior);
                    break; 
                }
                case "Coin_Slow":
                {
                    var newBehavior = _behaviorFactory.Create(CharacterBehaviorType.Slow);
                    _character.ChangeBehavior(newBehavior);
                    break;
                }
                case "Coin_Fast":
                {
                    var newBehavior = _behaviorFactory.Create(CharacterBehaviorType.Fast);
                    _character.ChangeBehavior(newBehavior);
                    break;
                }
            }
        }

        private async void OnJumpPressed(Types.Unit unit)
        {
            await _character.Jump();
        }

        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            _defaultBehavior = _behaviorFactory.Create(CharacterBehaviorType.Default);
            _character.ChangeBehavior(_defaultBehavior);
            await _character.Run(token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _disposables.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }
}
using System.Threading;
using App.Domains.Character.Model;
using App.Domains.Character.Model.Behaviors;
using Character.Controller.Inputs;
using Character.Model;
using Character.View;
using Cysharp.Threading.Tasks;
using Infra.Controllers;
using UniRx;

namespace Character.Controller
{
    public class CharacterController : ControllerBase
    {
        private readonly ICharacter _character;
        private readonly ICharacterPhysics _physics;
        private readonly ICharacterView _view;
        private readonly IInputCharacterController _inputCharacterController;

        private readonly ICharacterBehavior _defaultBehavior;
        private readonly ICharacterBehavior _flyBehavior;
        public CharacterController(
            ICharacter character,
            ICharacterPhysics physics, 
            IInputCharacterController inputCharacterController)
        {
            _character = character;
            _physics = physics;
            _inputCharacterController = inputCharacterController;

            var settings = new CharacterSettings();
            _defaultBehavior = new DefaultCharacterBehavior(_physics, settings);
            _flyBehavior = new FlyCharacterBehavior(_physics, settings);
            
            _disposable.Add(_physics.Collider.Subscribe(OnCollider));
            
            _inputCharacterController.JumpPressed += OnJumpPressedExecuted;
        }

        private async void OnCollider(string objectTag)
        {
            switch (objectTag)
            {
                case "Obstacle":
                    await _character.Idle();
                    break;
                case "Coin":
                    _character.ChangeBehavior(_flyBehavior);
                    break;
            }
        }

        private async void OnJumpPressedExecuted()
        {
            await _character.Jump();
        }

        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            _character.ChangeBehavior(_defaultBehavior);
            await _character.Run(token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _inputCharacterController.JumpPressed -= OnJumpPressedExecuted;
            }
            
            base.Dispose(disposing);
        }
    }
}
using System.Threading;
using Character.Controller.Inputs;
using Character.Model;
using Character.View;
using Cysharp.Threading.Tasks;

namespace Character.Controller
{
    public class CharacterController : ControllerBase
    {
        private readonly ICharacter _character;
        private readonly ICharacterView _view;
        private readonly IInputCharacterController _inputCharacterController;

        public CharacterController(
            ICharacter character,
            IInputCharacterController inputCharacterController)
        {
            _character = character;
            _inputCharacterController = inputCharacterController;
            
            _inputCharacterController.JumpPressed += OnJumpPressedExecuted;
        }

        private async void OnJumpPressedExecuted()
        {
            await _character.Jump();
        }

        protected override async UniTask OnStarted(CancellationToken token = default)
        {
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
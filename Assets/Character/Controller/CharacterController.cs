using System.Threading;
using Character.Controller.Inputs;
using Character.Model;
using Character.View;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Controller
{
    public class CharacterController : ControllerBase
    {
        private readonly ICharacter _character;
        private readonly ICharacterView _view;
        private readonly IInputCharacterController _inputCharacterController;

        public CharacterController(
            ICharacter character,
            ICharacterView view,
            IInputCharacterController inputCharacterController)
        {
            _character = character;
            _view = view;
            _inputCharacterController = inputCharacterController;
            
            _inputCharacterController.JumpPressed += OnJumpPressedExecuted;
        }

        private async void OnJumpPressedExecuted()
        {
            await _view.Jump();
        }

        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _view.Move(token);
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
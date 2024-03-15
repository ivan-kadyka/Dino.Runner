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
            
            _inputCharacterController.Jumped += OnJumpedExecuted;
        }

        private async void OnJumpedExecuted()
        {
            await _view.Jump();
        }


        protected override UniTask OnStarted(CancellationToken token = default)
        {
            Debug.Log("CharacterController: Started");
            
            return base.OnStarted(token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _inputCharacterController.Jumped -= OnJumpedExecuted;
            }
            
            base.Dispose(disposing);
        }
    }
}
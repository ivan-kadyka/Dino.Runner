using System.Threading;
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

        public CharacterController(ICharacter character, ICharacterView view)
        {
            _character = character;
            _view = view;
        }


        protected override UniTask OnStarted(CancellationToken token = default)
        {
            Debug.Log("CharacterController: Started");
            
            return base.OnStarted(token);
        }
    }
}
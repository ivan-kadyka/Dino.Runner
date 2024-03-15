using System.Threading;
using Character.Controller;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Controllers.Round
{
    public class RoundController : ControllerBase
    {
        private readonly IView _ground;
        private readonly IController _characterController;
        
        public RoundController(IController characterController, IView ground)
        {
            _ground = ground;
            _characterController = characterController;
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _characterController.Start(token);
        }
    }
}
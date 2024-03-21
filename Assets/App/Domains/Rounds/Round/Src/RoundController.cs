using System.Threading;
using App.GameCore;
using Cysharp.Threading.Tasks;
using Infra.Controllers;
using Infra.Controllers.Base;

namespace App.Round
{
    internal class RoundController : ControllerBase
    {
        private readonly IController _characterController;
        private readonly IController _obstaclesController;

        public RoundController(
            IController characterController,
            IController obstaclesController,
            IRoundView roundView,
            IGameContext gameContext)
        {
            _characterController = characterController;
            _obstaclesController = obstaclesController;
            
            roundView.SetUp(gameContext);
        }
        
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _obstaclesController.Start(token);
            await _characterController.Start(token);
        }

        protected override async UniTask OnStopped(CancellationToken token = default)
        {
            await _obstaclesController.Stop(token);
            await _characterController.Stop(token);
            
            await base.OnStopped(token);
        }
    }
}
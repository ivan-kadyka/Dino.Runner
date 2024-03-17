using System.Threading;
using Character.Controller;
using Character.Model;
using Controllers.Round.View;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Controllers.Round
{
    public class RoundController : ControllerBase
    {
        private readonly IRoundView _roundView;
        private readonly IController _characterController;
        private readonly IController _obstaclesController;

        public RoundController(
            IController characterController,
            IController obstaclesController,
            IRoundView roundView,
            ICharacterContext characterContext)
        {
            _roundView = roundView;
            _characterController = characterController;
            _obstaclesController = obstaclesController;

            _disposable.Add(characterContext.Speed.Subscribe(OnUpdateSpeed));
        }

        private void OnUpdateSpeed(float speed)
        {
            _roundView.SetUp(speed);
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _obstaclesController.Start(token);
            
            GameManager.Instance.NewGame(); // temp
            await _characterController.Start(token);
        }

        protected override async UniTask OnStopped(CancellationToken token = default)
        {
            await _obstaclesController.Stop(token);
            
            await base.OnStopped(token);
        }
    }
}
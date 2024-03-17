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

        public RoundController(
            IController characterController,
            IRoundView roundView,
            ICharacterContext characterContext)
        {
            _roundView = roundView;
            _characterController = characterController;
            
            _disposable.Add(characterContext.Speed.Subscribe(OnUpdateSpeed));
        }

        private void OnUpdateSpeed(float speed)
        {
            _roundView.SetUp(speed);
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            GameManager.Instance.NewGame(); // temp
            await _characterController.Start(token);
        }
    }
}
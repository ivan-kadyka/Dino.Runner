using System.Threading;
using Character.Controller;
using Cysharp.Threading.Tasks;

namespace Controllers.RetryPopup
{
    public class RetryPopupController : ControllerBase
    {
        private readonly IPopupView _popupView;

        public RetryPopupController(IPopupView popupView)
        {
            _popupView = popupView;
        }
        
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            await _popupView.Show(token);
        }
    }
}
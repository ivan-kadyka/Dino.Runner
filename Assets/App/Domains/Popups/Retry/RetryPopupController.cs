using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Controllers;
using Infra.Controllers.View;

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
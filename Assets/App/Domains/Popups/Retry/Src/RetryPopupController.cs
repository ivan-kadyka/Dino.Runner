using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Controllers.Base;
using Infra.Controllers.View;

namespace App.Popups.Retry
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
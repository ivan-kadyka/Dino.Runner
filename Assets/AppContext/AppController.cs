using System;
using System.Threading;
using Character.Controller;
using Controllers;
using Cysharp.Threading.Tasks;

namespace AppContext
{
    public class AppController : ControllerBase
    {
        private readonly IController _roundController;
        private readonly IController _retryPopupController;

        public AppController(IController roundController, IController retryPopupController)
        {
            _roundController = roundController;
            _retryPopupController = retryPopupController;
        }

        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            try
            {
                await _roundController.Start(token);
            }
            catch (OperationCanceledException)
            {
            }
        }

        protected override async UniTask OnStopped(CancellationToken token = default)
        {
            await _retryPopupController.Start(token);
        }
    }
}
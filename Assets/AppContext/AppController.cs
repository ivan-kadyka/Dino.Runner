using System;
using System.Threading;
using Character.Controller;
using Controllers;
using Cysharp.Threading.Tasks;
using UnityEngine;

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
                while (!token.IsCancellationRequested)
                {
                    await _roundController.Run(token);

                    await _retryPopupController.Run(token);
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception e)
            {
                Debug.Log(e);
                //here high level generic handling logic for unhandled exceptions.
                //for example: show popup "Something went wrong" and send logs to analytics
            }
        }
    }
}
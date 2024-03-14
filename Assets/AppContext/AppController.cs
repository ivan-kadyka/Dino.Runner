using System.Threading;
using Character.Controller;
using Controllers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AppContext
{
    public class AppController : ControllerBase
    {
        private readonly IController _characterController;

        public AppController(IController characterController)
        {
            _characterController = characterController;
        }

        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            Debug.Log("AppController: Started");

            await _characterController.Start(token);
        }
    }
}
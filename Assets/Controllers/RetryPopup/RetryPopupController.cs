using System.Threading;
using Character.Controller;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Controllers.RetryPopup
{
    public class RetryPopupController : ControllerBase
    {
        protected override async UniTask OnStarted(CancellationToken token = default)
        {
            Debug.Log("RetryPopupController started");

            await UniTask.Never(token);
        }
    }
}
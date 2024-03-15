using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Controllers.RetryPopup
{
    public class RetryPopupView : MonoBehaviour, IPopupView
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public UniTask Show(CancellationToken token = default)
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
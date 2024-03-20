using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Controllers;
using Infra.Controllers.View;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.RetryPopup
{
    public class RetryPopupView : MonoBehaviour, IPopupView
    {
        [SerializeField] private Button restartButton;

        private UniTaskCompletionSource _taskCompletionSource;
        
        private void Awake()
        {
            gameObject.SetActive(false);
            
            restartButton.onClick.AddListener(OnRestartClicked);
        }

        private void OnRestartClicked()
        {
            _taskCompletionSource.TrySetResult();
        }

        public async UniTask Show(CancellationToken token = default)
        {
            _taskCompletionSource = new UniTaskCompletionSource();
            gameObject.SetActive(true);

            await _taskCompletionSource.Task;
            gameObject.SetActive(false);
        }
        
        public void Dispose()
        {
            restartButton.onClick.RemoveListener(OnRestartClicked);
            
            Destroy(gameObject);
        }
    }
}
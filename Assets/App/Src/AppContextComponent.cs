using System.Threading;
using UnityEngine;
using Zenject;

namespace App
{
    internal class AppContextComponent : MonoBehaviour
    {
        [Inject]
        private AppController _appController;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        private void Awake()
        {
            // to force frame rate, especially for mobile devices
            Application.targetFrameRate = 60;
        }

        async void Start()
        {
            await _appController.Start(_cancellationSource.Token);
        }

        private void OnDestroy()
        {
            _cancellationSource.Cancel();
            _appController.Dispose();
        }
    }
}

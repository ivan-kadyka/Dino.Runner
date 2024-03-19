using System.Threading;
using AppContext;
using UnityEngine;
using Zenject;

public class AppContextComponent : MonoBehaviour
{
    [Inject]
    private AppController appController;

    private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
    
    async void Start()
    {
        Application.targetFrameRate = 60;
        await appController.Start(_cancellationSource.Token);
    }

    private void OnDestroy()
    {
        _cancellationSource.Cancel();
    }
}

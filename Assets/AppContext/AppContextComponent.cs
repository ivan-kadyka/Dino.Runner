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
        var token = _cancellationSource.Token;
        
        while (!token.IsCancellationRequested)
        {
            await appController.Start(token);
            await appController.Stop(token);
        }
    }

    private void OnDestroy()
    {
        _cancellationSource.Cancel();
    }
}

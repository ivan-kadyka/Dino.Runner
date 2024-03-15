using System;
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

        try
        {
            while (!token.IsCancellationRequested)
            {
                await appController.Start(token);
                await appController.Stop(token);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    private void OnDestroy()
    {
        _cancellationSource.Cancel();
    }
}

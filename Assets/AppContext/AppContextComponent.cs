using AppContext;
using UnityEngine;
using Zenject;

public class AppContextComponent : MonoBehaviour
{
    [Inject]
    private AppController appController;
    
    async void Start()
    {
        await appController.Start();
    }
}

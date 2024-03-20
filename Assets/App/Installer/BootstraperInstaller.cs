using AppContext;
using Controllers;
using Controllers.RetryPopup;
using Models;
using Models.Tickable;
using UnityEngine;
using Zenject;


public class BootstraperInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject RentryPopupPrefab;
    
    [SerializeField]
    private GameObject Canvas;
    
    [SerializeField]
    private GameObject _tickableGameObject;

    public override void InstallBindings()
    {
        // App Controller
        Container.Bind<AppController>()
            .FromMethod(it => new AppController(
                it.Container.ResolveId<IController>("TopPanelController"),
                it.Container.ResolveId<IController>("RoundController"),
                it.Container.ResolveId<IController>("RetryPopupController")
            ))
            .AsSingle();
        
        // Retry popup
        Container.Bind<IPopupView>()
            .WithId("RetryPopupView")
            .To<RetryPopupView>()
            .FromComponentInNewPrefab(RentryPopupPrefab)
            .UnderTransform(Canvas.transform)
            .AsCached();
        
        Container.Bind<IController>().WithId("RetryPopupController")
            .FromMethod(it => new RetryPopupController(
            it.Container.ResolveId<IPopupView>("RetryPopupView")
        )).AsCached();
        
        // Utils
        var tickableComponent = _tickableGameObject.GetComponent<TickableContext>();
        Container.Rebind<ITickableContext>().FromInstance(tickableComponent);
    }
}
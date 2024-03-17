using AppContext;
using Character.Controller.Inputs;
using Character.Model;
using Character.View;
using Controllers;
using Controllers.RetryPopup;
using Controllers.Round;
using Controllers.Round.View;
using Controllers.TopPanel;
using Models;
using Models.Tickable;
using UnityEngine;
using Zenject;

public class BootstraperInstaller : MonoInstaller
{
    [SerializeField] 
    private GameObject CharacterPrefab;

    [SerializeField]
    private GameObject RoundPrefab;
    
    [SerializeField]
    private GameObject RentryPopupPrefab;
    
    [SerializeField]
    private GameObject _topPanelPrefab;
    
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

        // Character
        Container.Bind<IInputCharacterController>().To<InputCharacterController>().FromComponentsInHierarchy()
            .AsSingle();
        Container.BindInterfacesTo<Character.Model.Character>().AsSingle();
        Container.BindInterfacesTo<CharacterView>().FromComponentInNewPrefab(CharacterPrefab).AsSingle();
        Container.Bind<IController>().WithId("CharacterController").To<Character.Controller.CharacterController>()
            .AsSingle();
        
        // Top Panel
        Container.Bind<ITopPanelView>()
            .To<TopPanelView>()
            .FromComponentInNewPrefab(_topPanelPrefab)
            .UnderTransform(Canvas.transform)
            .AsSingle();
        
        Container.Bind<IController>().WithId("TopPanelController").To<TopPanelController>()
            .AsSingle();

        //Round
        Container.Bind<IRoundView>().To<Ground>().FromComponentInNewPrefab(RoundPrefab).AsSingle();

        Container.Bind<IController>().WithId("RoundController")
            .FromMethod(it => new RoundController(
                it.Container.ResolveId<IController>("CharacterController"),
                it.Container.Resolve<IRoundView>(),
                it.Container.Resolve<ICharacterContext>())).AsSingle();

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
        Container.Rebind<ITickableContext>().FromInstance(tickableComponent).AsSingle();
    }
}
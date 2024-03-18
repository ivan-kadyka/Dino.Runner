using App.Domains.Spawner;
using App.Domains.Spawner.Coins;
using App.Domains.Spawner.Coins.Factory;
using App.Domains.Spawner.Obstacle;
using App.Models;
using AppContext;
using Character.Controller.Inputs;
using Character.Model;
using Character.View;
using Controllers;
using Controllers.RetryPopup;
using Controllers.Round;
using Controllers.Round.View;
using Controllers.Spawner.Coins.Factory;
using Controllers.Spawner.Obstacle.Factory;
using Controllers.Spawner.Obstacle.Model;
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
    
    [SerializeField]
    private ObstacleScriptableObject _obstacleObjects;

    [SerializeField] 
    private CoinsScriptableObject _coinsScriptableObject;

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
        Container.Bind<IInputCharacterController>()
            .To<InputCharacterController>()
            .FromComponentsInHierarchy()
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
                it.Container.ResolveId<IController>("CompositeSpawnerController"),
                it.Container.Resolve<IRoundView>(),
                it.Container.Resolve<ICharacterContext>())).AsSingle();
        
        // Spawner
        // Obstacles
        
        Container.Bind<IController>().WithId("CompositeSpawnerController")
            .FromMethod(it => new CompositeSpawnerController(
                it.Container.Resolve<SpawnSettings>(),
                    it.Container.ResolveId<ISpawnerController>("ObstaclesController"),
                //    it.Container.ResolveId<ISpawnerController>("CoinController"),
                it.Container.Resolve<ITickableContext>()));

        Container.BindInstance(new SpawnSettings(1, 1.5f)).AsSingle();
        
      
        Container.Bind<IObstacleFactory>().FromMethod(it =>
            new ObstacleFactory(it.Container, _obstacleObjects, it.Container.Resolve<IGameContext>())).AsSingle();

        Container.Bind<ISpawnerController>() 
            .WithId("ObstaclesController")
            .To<ObstaclesController>().AsSingle();

        
        Container.Bind<IObstacleSettings>().FromInstance(new ObstacleSettings(_obstacleObjects));
        
        /*

      Container.Bind<ISpawnerController>()
          .WithId("CoinController")
          .To<CoinSpawnerController>().AsSingle();

      Container.Bind<ICoinFactory>().FromMethod(it =>
          new CoinFactory(it.Container, _coinsScriptableObject)).AsSingle();
      */
        
      
        
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
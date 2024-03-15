using AppContext;
using Character.Controller.Inputs;
using Character.Model;
using Character.View;
using Controllers;
using Controllers.RetryPopup;
using Controllers.Round;
using UnityEngine;
using Zenject;

public class BootstraperInstaller : MonoInstaller
{
    [SerializeField] private GameObject CharacterPrefab;

    [SerializeField] private GameObject RoundPrefab;
    
    [SerializeField] private GameObject RentryPopupPrefab;

    public override void InstallBindings()
    {
        // App Controller
        Container.Bind<AppController>()
            .FromMethod(it => new AppController(
                it.Container.ResolveId<IController>("RoundController"),
                it.Container.ResolveId<IController>("RetryPopupController")
            ))
            .AsSingle();

        // Character
        Container.Bind<IInputCharacterController>().To<InputCharacterController>().FromComponentsInHierarchy()
            .AsSingle();
        Container.Bind<ICharacter>().To<Character.Model.Character>().AsSingle();
        Container.Bind<ICharacterView>().To<CharacterView>().FromComponentInNewPrefab(CharacterPrefab).AsSingle();
        Container.Bind<IController>().WithId("CharacterController").To<Character.Controller.CharacterController>()
            .AsSingle();

        //Round
        Container.Bind<IView>().WithId("RoundView").To<Ground>().FromComponentInNewPrefab(RoundPrefab).AsSingle();

        Container.Bind<IController>().WithId("RoundController")
            .FromMethod(it => new RoundController(
                it.Container.ResolveId<IController>("CharacterController"),
                it.Container.ResolveId<IView>("RoundView"))).AsSingle();

        // Retry popup
        Container.Bind<IPopupView>().WithId("RetryPopupView").To<RetryPopupView>().FromComponentInNewPrefab(RentryPopupPrefab).AsCached();
        Container.Bind<IController>().WithId("RetryPopupController")
            .FromMethod(it => new RetryPopupController(
            it.Container.ResolveId<IPopupView>("RetryPopupView")
        )).AsCached();
    }
}
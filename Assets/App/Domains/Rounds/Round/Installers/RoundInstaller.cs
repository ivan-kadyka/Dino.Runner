using App.GameCore;
using Infra.Controllers;
using UnityEngine;
using Zenject;

namespace App.Round
{
    public class RoundInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _roundPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<IRoundView>().To<Ground>().FromComponentInNewPrefab(_roundPrefab).AsSingle();

            Container.Bind<IController>().WithId("RoundController")
                .FromMethod(it => new RoundController(
                    it.Container.ResolveId<IController>("CharacterController"),
                    it.Container.ResolveId<IController>("CompositeSpawnerController"),
                    it.Container.Resolve<IRoundView>(),
                    it.Container.Resolve<IGameContext>())).AsSingle();
        }
    }
}
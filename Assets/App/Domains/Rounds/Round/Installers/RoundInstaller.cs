using App.Models;
using Controllers;
using Controllers.Round;
using Controllers.Round.View;
using UnityEngine;
using Zenject;

namespace App.Domains.Rounds.Round.Installers
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
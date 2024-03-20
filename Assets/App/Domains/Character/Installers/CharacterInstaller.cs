using App.Domains.Character.Controller.Inputs;
using App.Domains.Character.Model;
using App.Domains.Character.Model.Behaviors.Context;
using App.Domains.Character.Model.Behaviors.Factory;
using App.Domains.Character.Model.Behaviors.Jump.Factory;
using App.Models;
using Character.Model;
using Character.View;
using Controllers;
using Infra.Controllers;
using UnityEngine;
using Zenject;
using CharacterController = Character.Controller.CharacterController;
using CharacterModel = App.Domains.Character.Model.Character;

namespace AppContext.Installer
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] 
        private GameObject CharacterPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<IInputCharacterController>()
                .To<InputCharacterController>()
                .FromComponentsInHierarchy()
                .AsSingle();
            
            Container.Bind<CharacterModel>().AsSingle();
            Container.Bind<ICharacter>().FromMethod(it => it.Container.Resolve<CharacterModel>()).AsSingle();
            Container.Bind<IGameContext>().FromMethod(it => it.Container.Resolve<CharacterModel>()).AsSingle();
            
            Container.Bind<ICharacterPhysics>().To<CharacterView>().FromComponentInNewPrefab(CharacterPrefab).AsSingle();
        
            Container.Bind<CharacterController>().AsSingle();
            Container.Bind<IController>()
                .WithId("CharacterController")
                .FromMethod(it => it.Container.Resolve<CharacterController>());
            Container.Bind<ICharacterBehaviorContext>()
                .FromMethod(it => it.Container.Resolve<CharacterController>());

            Container.Bind<ICharacterBehaviorFactory>().To<CharacterBehaviorFactory>().AsSingle();
            Container.Bind<IJumpBehaviorFactory>().To<JumpBehaviorFactory>().AsSingle();
            Container.BindInstance(new CharacterSettings());
        }

    }
}
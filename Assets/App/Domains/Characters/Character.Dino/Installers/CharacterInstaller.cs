using App.GameCore;
using Infra.Controllers;
using UnityEngine;
using Zenject;

namespace App.Character.Dino
{
    internal class CharacterInstaller : MonoInstaller
    {
        [SerializeField] 
        private GameObject _characterPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<IInputCharacterController>()
                .To<InputCharacterController>()
                .FromComponentsInHierarchy()
                .AsSingle();
            
            Container.Bind<GameContext.GameContext>().AsSingle();
            Container.Bind<IGameContext>().FromMethod(it => it.Container.Resolve<GameContext.GameContext>()).AsSingle();

            Container.Bind<Character>().AsSingle();
            
            Container.Bind<ICharacter>().FromMethod(it =>
            {
                var character = it.Container.Resolve<Character>();
                var gameContext = it.Container.Resolve<GameContext.GameContext>();
                gameContext.Set(character);
                return character;
            }).AsSingle();
          
            Container.Bind<ICharacterStateContext>()
                .FromMethod(it => it.Container.Resolve<Character>());
            
            Container.Bind<CharacterView>().FromComponentInNewPrefab(_characterPrefab).AsSingle();
            Container.Bind<ICharacterPhysics>().FromMethod(it => it.Container.Resolve<CharacterView>()).AsSingle();
            Container.Bind<ICharacterSounds>().FromMethod(it => it.Container.Resolve<CharacterView>()).AsSingle();
        
            Container.Bind<CharacterController>().AsSingle();
            Container.Bind<IController>()
                .WithId("CharacterController")
                .FromMethod(it => it.Container.Resolve<CharacterController>());


            Container.Bind<ICharacterBehaviorFactory>().To<CharacterBehaviorFactory>().AsSingle();
            Container.Bind<IJumpBehaviorFactory>().To<JumpBehaviorFactory>().AsSingle();
            Container.BindInstance(new CharacterSettings());
        }

    }
}
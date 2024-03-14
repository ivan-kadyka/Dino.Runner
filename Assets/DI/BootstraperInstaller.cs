using AppContext;
using Character.Model;
using Character.View;
using Controllers;
using UnityEngine;
using Zenject;

public class BootstraperInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject CharacterPrefab;
    
    public override void InstallBindings()
    {
        Debug.Log("Bootstraper Installer InstallBindings"); 
      
        Container.Bind<AppController>().AsSingle();
        
        Container.Bind<ICharacter>().To<Character.Model.Character>().AsSingle();
        Container.Bind<ICharacterView>().To<CharacterView>().FromComponentInNewPrefab(CharacterPrefab).AsSingle();
        Container.Bind<IController>().To<Character.Controller.CharacterController>().AsSingle();
    }
}
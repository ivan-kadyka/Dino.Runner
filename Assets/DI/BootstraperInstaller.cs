using AppContext;
using Character.View;
using UnityEngine;
using Zenject;

public class BootstraperInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject CharacterPrefab;
    
    public override void InstallBindings()
    {
        Debug.Log("Bootstraper Installer InstallBindings"); 
        Container.Bind<ICharacterView>().FromComponentInNewPrefab(CharacterPrefab).AsSingle();
        Container.Bind<AppController>().AsSingle();
    }
}
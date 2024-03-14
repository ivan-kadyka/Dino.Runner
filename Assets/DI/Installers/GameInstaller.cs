using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject CharacterPrefab;

    public override void InstallBindings()
    {
        Debug.Log("GameInstaller InstallBindings");
      //  Container.Bind<ICharacter>().FromComponentInNewPrefab(CharacterPrefab).AsSingle();
    }
}
using App.GameCore;
using App.Spawner.Coins.Settings;
using UnityEngine;
using Zenject;

namespace App.Spawner.Coins
{
    public class CoinSpawnerInstaller : MonoInstaller
    {
        [SerializeField] 
        private CoinsScriptableObject _coinsScriptableObject;

        [SerializeField]
        private GameObject _spawnPoolContainer;
        public override void InstallBindings()
        {
            Container.Bind<ISpawnerController>()
                .WithId("CoinController")
                .To<CoinSpawnerController>().AsSingle();

            Container.Bind<ICoinFactory>().FromMethod(it =>
                new CoinFactory(it.Container, _coinsScriptableObject,  _spawnPoolContainer.transform, it.Container.Resolve<IGameContext>())).AsSingle();

            Container.Bind<ICoinsSettings>().FromInstance(new CoinsSettings(_coinsScriptableObject));
        }
    }
}
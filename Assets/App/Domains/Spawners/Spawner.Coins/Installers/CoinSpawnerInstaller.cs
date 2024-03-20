using App.GameCore;
using UnityEngine;
using Zenject;

namespace App.Spawner.Coins
{
    public class CoinSpawnerInstaller : MonoInstaller
    {
        [SerializeField] 
        private CoinsScriptableObject _coinsScriptableObject;
        public override void InstallBindings()
        {
            Container.Bind<ISpawnerController>()
                .WithId("CoinController")
                .To<CoinSpawnerController>().AsSingle();

            Container.Bind<ICoinFactory>().FromMethod(it =>
                new CoinFactory(it.Container, _coinsScriptableObject, it.Container.Resolve<IGameContext>())).AsSingle();
        }
    }
}
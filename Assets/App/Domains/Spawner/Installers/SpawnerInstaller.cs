using App.Domains.GameCore.Src;
using App.Domains.Spawner.Coins;
using App.Domains.Spawner.Coins.Factory;
using App.Domains.Spawner.Obstacle;
using App.Models;
using Controllers;
using Controllers.Spawner.Obstacle.Factory;
using Controllers.Spawner.Obstacle.Model;
using Infra.Components.Tickable;
using Infra.Controllers;
using UnityEngine;
using Zenject;

namespace App.Domains.Spawner.Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        private ObstacleScriptableObject _obstacleObjects;

        [SerializeField] 
        private CoinsScriptableObject _coinsScriptableObject;
        
        public override void InstallBindings()
        {
            // Generic
            Container.Bind<IController>().WithId("CompositeSpawnerController")
                .FromMethod(it => new CompositeSpawnerController(
                    it.Container.Resolve<SpawnSettings>(),
                    it.Container.ResolveId<ISpawnerController>("ObstaclesController"),
                    it.Container.ResolveId<ISpawnerController>("CoinController"),
                    it.Container.Resolve<ITickableContext>()));

            Container.BindInstance(new SpawnSettings()).AsSingle();
        
            // Obstacles
            Container.Bind<IObstacleFactory>().FromMethod(it =>
                new ObstacleFactory(it.Container, _obstacleObjects, it.Container.Resolve<IGameContext>())).AsSingle();

            Container.Bind<ISpawnerController>() 
                .WithId("ObstaclesController")
                .To<ObstaclesController>().AsSingle();

        
            Container.Bind<IObstacleSettings>().FromInstance(new ObstacleSettings(_obstacleObjects));
        
            // Coins
            Container.Bind<ISpawnerController>()
                .WithId("CoinController")
                .To<CoinSpawnerController>().AsSingle();

            Container.Bind<ICoinFactory>().FromMethod(it =>
                new CoinFactory(it.Container, _coinsScriptableObject, it.Container.Resolve<IGameContext>())).AsSingle();
        }
    }
}
using App.GameCore;
using Controllers.Spawner.Obstacle.Model;
using UnityEngine;
using Zenject;

namespace App.Spawner.Obstacle
{
    internal class ObstacleSpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        private ObstacleScriptableObject _obstacleObjects;
        
        [SerializeField]
        private GameObject _spawnPoolContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<IObstacleFactory>().FromMethod(it =>
                new ObstacleFactory(it.Container,
                    _obstacleObjects,
                    _spawnPoolContainer.transform,
                    it.Container.Resolve<IGameContext>(),
                    it.Container.Resolve<IColliderObjectObserver>())).AsSingle();

            Container.Bind<ISpawnerController>() 
                .WithId("ObstaclesController")
                .To<ObstaclesController>().AsSingle();

        
            Container.Bind<IObstacleSettings>().FromInstance(new ObstacleSettings(_obstacleObjects));
         
        }
    }
}
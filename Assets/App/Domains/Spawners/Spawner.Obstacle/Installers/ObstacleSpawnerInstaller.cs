using App.GameCore;
using Controllers.Spawner.Obstacle.Model;
using UnityEngine;
using Zenject;

namespace App.Spawner.Obstacle
{
    public class ObstacleSpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        private ObstacleScriptableObject _obstacleObjects;
        
        public override void InstallBindings()
        {
            Container.Bind<IObstacleFactory>().FromMethod(it =>
                new ObstacleFactory(it.Container, _obstacleObjects, it.Container.Resolve<IGameContext>())).AsSingle();

            Container.Bind<ISpawnerController>() 
                .WithId("ObstaclesController")
                .To<ObstaclesController>().AsSingle();

        
            Container.Bind<IObstacleSettings>().FromInstance(new ObstacleSettings(_obstacleObjects));
         
        }
    }
}
using System.Collections.Generic;
using System.Threading;
using Character.Controller;
using Controllers.Spawner.Obstacle.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Controllers.Spawner.Obstacle
{
    public class ObstaclesController : ControllerBase
    {
        private readonly IObstacleFactory _obstacleFactory;
        
        private float minSpawnRate = 1f;
        private float maxSpawnRate = 2f;

        private readonly List<IObstacleView> _obstacles = new List<IObstacleView>();

        public ObstaclesController(IObstacleFactory obstacleFactory)
        {
            _obstacleFactory = obstacleFactory;
        }
        
        protected override UniTask OnStarted(CancellationToken token = default)
        {
            StartSpawn();
            
            return base.OnStarted(token);
        }
        
        private void StartSpawn()
        {
            float spawnChance = Random.value;

            /*
            foreach (var obj in objects)
            {
                if (spawnChance < obj.spawnChance)
                {
                    GameObject obstacle = Instantiate(obj.prefab);
                    obstacle.transform.position += transform.position;
                    break;
                }

                spawnChance -= obj.spawnChance;
            }

            Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
            */
        }
    }
}
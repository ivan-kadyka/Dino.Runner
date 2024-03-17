using System.Linq;

namespace Controllers.Spawner.Obstacle.Model
{
    public class ObstacleSettings : IObstacleSettings
    {
        public float MinSpawnRate { get; }
        public float MaxSpawnRate { get; }
        public float[] ObjectChances { get; }

        public ObstacleSettings(ObstacleScriptableObject data)
        {
            MinSpawnRate = data.minSpawnRate;
            MaxSpawnRate = data.maxSpawnRate;
            ObjectChances = data.items.Select(it => it.spawnChance).ToArray();
        }
    }
}
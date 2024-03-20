using System.Linq;

namespace Controllers.Spawner.Obstacle.Model
{
    public class ObstacleSettings : IObstacleSettings
    {
        public float[] ObjectChances { get; }

        public ObstacleSettings(ObstacleScriptableObject data)
        {
            ObjectChances = data.items.Select(it => it.spawnChance).ToArray();
        }
    }
}
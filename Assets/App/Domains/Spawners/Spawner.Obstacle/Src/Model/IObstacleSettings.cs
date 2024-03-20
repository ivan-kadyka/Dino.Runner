namespace Controllers.Spawner.Obstacle.Model
{
    public interface IObstacleSettings
    {
        float MinSpawnRate { get; }
        
        float MaxSpawnRate { get; }
        
        float[] ObjectChances { get; }
    }
}
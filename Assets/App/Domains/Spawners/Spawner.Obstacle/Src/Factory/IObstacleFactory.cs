namespace App.Spawner.Obstacle
{
    /// <summary>
    /// Specifies a factory interface for creating obstacle spawn views, conforming to the generic
    /// spawn factory interface with specific types for options and views.
    /// </summary>
    internal interface IObstacleFactory : ISpawnFactory<SpawnOptions, ISpawnView>
    {
    }

}
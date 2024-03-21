namespace App.Spawner.Coins
{
    /// <summary>
    /// Specifies a factory interface for creating coin spawn views, conforming to the generic spawn factory
    /// interface with specific types for options and views.
    /// </summary>
    internal interface ICoinFactory : ISpawnFactory<SpawnOptions, ISpawnView>
    {
    }
}
namespace Controllers.Spawner.Obstacle.Model
{
    /// <summary>
    /// Defines an interface for accessing obstacle settings, specifically the probabilities or chances associated with different obstacles appearing in the game.
    /// </summary>
    internal interface IObstacleSettings
    {
        /// <summary>
        /// Gets an array of float values, each representing the chance or probability of a specific obstacle's appearance.
        /// </summary>
        float[] ObjectChances { get; }
    }

}
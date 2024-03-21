namespace App.GameCore
{
    /// <summary>
    /// Enumerates the types of coins, each associated with a specific effect
    /// or characteristic that can be applied to or influence the game's characters or environment.
    /// </summary>
    public enum CoinType
    {
        /// <summary>
        /// Represents a coin that, when collected, applies a slow effect, possibly reducing movement or action speed.
        /// </summary>
        Slow,

        /// <summary>
        /// Represents a coin that, when collected, grants a fast effect, increasing movement or action speed.
        /// </summary>
        Fast,

        /// <summary>
        /// Represents a coin that, when collected, enables a fly effect, allowing for aerial movement or other fly-related abilities.
        /// </summary>
        Fly,
    }
}
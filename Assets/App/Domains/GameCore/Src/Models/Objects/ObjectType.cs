namespace App.GameCore
{
    /// <summary>
    /// Enumerates different types of objects that can exist within the game
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// Represents an object type that is not known or specified.
        /// </summary>
        Unknown,

        /// <summary>
        /// Represents a character
        /// </summary>
        Character,

        /// <summary>
        /// Represents an obstacle that players must avoid or overcome.
        /// </summary>
        Obstacle,

        /// <summary>
        /// Represents a coin or collectible that players can collect for rewards or points.
        /// </summary>
        Coin,
    }

}
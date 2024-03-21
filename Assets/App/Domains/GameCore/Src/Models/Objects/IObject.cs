namespace App.GameCore
{
    /// <summary>
    /// Defines a basic interface for game objects, allowing for the identification of the object's type within the game's ecosystem.
    /// </summary>
    public interface IObject
    {
        /// <summary>
        /// Gets the type of the object, as defined by the ObjectType enum.
        /// This property allows for easy identification and categorization of game objects.
        /// </summary>
        ObjectType ObjectType { get; }
    }

}
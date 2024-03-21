namespace App.GameCore
{
    /// <summary>
    /// Defines an interface for object views, which are visual representations of game objects.
    /// This interface allows for a direct association between the view and its corresponding game object.
    /// </summary>
    public interface IObjectView
    {
        /// <summary>
        /// Gets the game object associated with this view.
        /// This property allows for access to the underlying game object's properties and behaviors.
        /// </summary>
        IObject Object { get; }
    }

}
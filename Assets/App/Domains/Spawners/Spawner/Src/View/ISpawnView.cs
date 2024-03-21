using App.GameCore;
using Infra.Controllers.View;

namespace App.Spawner
{
    /// <summary>
    /// Extends the IView interface to define specific behavior for spawn views
    /// </summary>
    public interface ISpawnView : IView, IObjectView
    {
        /// <summary>
        /// Gets or sets a value indicating whether the spawn view is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Sets up the spawn view with necessary game context and assigns a name to the view.
        /// </summary>
        /// <param name="gameContext">The game context to associate with the spawn view.</param>
        /// <param name="spawnObject">The spawn game object</param>
        void SetUp(IGameContext gameContext, IObject spawnObject);
    }

}
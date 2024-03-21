using App.GameCore;
using Infra.Controllers.View;

namespace App.Round
{
    /// <summary>
    /// Extends the IView interface to define specific behavior for round views, including setup with game context to prepare for a new round.
    /// </summary>
    internal interface IRoundView : IView
    {
        /// <summary>
        /// Sets up the round view with necessary game context, preparing it for the upcoming round.
        /// </summary>
        /// <param name="gameContext">The game context to associate with the round view.</param>
        void SetUp(IGameContext gameContext);
    }
}
using System;
using App.Character;
using Infra.Controllers.View;

namespace App.TopPanel
{
    /// <summary>
    /// Extends the IView interface for a top panel view, specifically designed for displaying game-related
    /// information such as high scores, current scores, active character effects,
    /// and the remaining time for these effects.
    /// </summary>
    internal interface ITopPanelView : IView
    {
        /// <summary>
        /// Updates the display of the high score with the given value.
        /// </summary>
        /// <param name="value">The value of the high score to display.</param>
        void UpdateHiScore(int value);
    
        /// <summary>
        /// Updates the display of the current score with the given value.
        /// </summary>
        /// <param name="value">The value of the current score to display.</param>
        void UpdateScore(int value);

        /// <summary>
        /// Updates the display with the type of effect currently applied to the character.
        /// </summary>
        /// <param name="state">The current state or effect applied to the character.</param>
        void UpdateEffectType(CharacterState state);
    
        /// <summary>
        /// Updates the display with the remaining time for the current effect applied to the character.
        /// </summary>
        /// <param name="timeLeft">The time span indicating how much time is left for the effect.</param>
        void UpdateEffectTime(TimeSpan timeLeft);
    }

}
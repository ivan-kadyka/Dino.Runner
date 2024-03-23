using System;

namespace App.Character
{
    /// <summary>
    /// Represents the options for updating character effects, including the type of effect and the remaining time for that effect.
    /// </summary>
    public struct EffectUpdateOptions
    {
        /// <summary>
        /// Gets the specific character effect being applied.
        /// </summary>
        public CharacterEffect Effect { get; private set; }
    
        /// <summary>
        /// Gets the time span indicating how much time is left until the effect expires.
        /// </summary>
        public TimeSpan TimeLeft { get; private set; }

        /// <summary>
        /// Initializes a new instance of the EffectUpdateOptions struct with specified effect type and time left.
        /// </summary>
        /// <param name="effect">The character effect type.</param>
        /// <param name="timeLeft">The remaining duration of the effect.</param>
        public EffectUpdateOptions(CharacterEffect effect, TimeSpan timeLeft)
        {
            Effect = effect;
            TimeLeft = timeLeft;
        }
    }

}
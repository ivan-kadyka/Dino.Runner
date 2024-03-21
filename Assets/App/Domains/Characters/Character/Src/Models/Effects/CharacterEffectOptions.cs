using System;

namespace App.Character
{
    /// <summary>
    /// Represents the options for applying effects to a character, including the type of effect and its duration.
    /// </summary>
    public class CharacterEffectOptions
    {
        /// <summary>
        /// Gets the type of effect to be applied to the character.
        /// </summary>
        public CharacterEffect Type { get; }
    
        /// <summary>
        /// Gets the duration for which the effect is applied.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Initializes a new instance of the CharacterEffectOptions class with specified effect type and duration.
        /// </summary>
        /// <param name="type">The type of character effect.</param>
        /// <param name="duration">The duration of the effect.</param>
        public CharacterEffectOptions(CharacterEffect type, TimeSpan duration)
        {
            Type = type;
            Duration = duration;
        }
    }

}
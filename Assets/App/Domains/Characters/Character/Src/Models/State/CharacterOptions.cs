using System;

namespace App.Character
{
    /// <summary>
    /// Represents the options for applying effects to a character, including the type of effect and its duration.
    /// </summary>
    public class CharacterOptions
    {
        /// <summary>
        /// Gets the type of effect to be applied to the character.
        /// </summary>
        public CharacterState Type { get; }
    
        /// <summary>
        /// Gets the duration for which the effect is applied.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Initializes a new instance of the CharacterStateOptions class with specified effect type and duration.
        /// </summary>
        /// <param name="type">The type of character state.</param>
        /// <param name="duration">The duration of the state.</param>
        public CharacterOptions(CharacterState type, TimeSpan duration)
        {
            Type = type;
            Duration = duration;
        }
    }

}
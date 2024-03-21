using System;
using Infra.Observable;

namespace App.Character
{
    /// <summary>
    /// Defines a context for observing and managing character effects and their remaining durations.
    /// </summary>
    public interface ICharacterEffectContext
    {
        /// <summary>
        /// Gets an observable value representing the current effect applied to the character.
        /// </summary>
        IObservableValue<CharacterEffect> Effect { get; }
    
        /// <summary>
        /// An observable that emits the remaining duration of the current character effect.
        /// </summary>
        IObservable<TimeSpan> TimeLeft { get; }
    }
}
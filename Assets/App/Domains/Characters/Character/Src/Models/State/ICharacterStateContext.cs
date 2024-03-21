using System;
using Infra.Observable;

namespace App.Character
{
    /// <summary>
    /// Defines a context for observing and managing character states and their remaining durations.
    /// </summary>
    public interface ICharacterStateContext
    {
        /// <summary>
        /// Gets an observable value representing the current state applied to the character.
        /// </summary>
        IObservableValue<CharacterState> State { get; }
    
        /// <summary>
        /// An observable that emits the remaining duration of the current character state.
        /// </summary>
        IObservable<TimeSpan> TimeLeft { get; }
    }
}
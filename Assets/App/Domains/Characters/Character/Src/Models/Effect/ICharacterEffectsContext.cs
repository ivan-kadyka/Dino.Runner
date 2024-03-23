using System;
using System.Collections.Generic;
using Infra.Observable;

namespace App.Character
{
    /// <summary>
    /// Defines a context for observing and managing character effects and their remaining updates.
    /// </summary>
    public interface ICharacterEffectsContext
    {
        /// <summary>
        /// Gets an observable collection representing the current effects applied to the character.
        /// </summary>
        IObservableValue<IReadOnlyCollection<CharacterEffect>> Effects { get; }
        
        /// <summary>
        /// An observable that emits the remaining duration of the current character state.
        /// </summary>
        IObservable<EffectUpdateOptions> Updated { get; }
    }
}
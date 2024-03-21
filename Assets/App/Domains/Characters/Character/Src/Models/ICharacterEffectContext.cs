using System;
using Infra.Observable;

namespace App.Character
{
    public interface ICharacterEffectContext
    {
        IObservableValue<CharacterEffect> Effect { get; }
        
        IObservable<TimeSpan> TimeLeft { get; }
    }
}
using System;
using Infra.Observable;

namespace App.Character
{
    public interface ICharacterEffectContext
    {
        IObservableValue<CharacterEffect> CurrentType { get; }
        
        IObservable<TimeSpan> TimeLeft { get; }
    }
}
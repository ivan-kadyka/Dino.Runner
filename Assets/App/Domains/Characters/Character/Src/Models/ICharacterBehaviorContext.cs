using System;
using Infra.Observable;

namespace App.Character
{
    public interface ICharacterBehaviorContext
    {
        IObservableValue<CharacterBehaviorType> CurrentType { get; }
        
        IObservable<TimeSpan> TimeLeft { get; }
    }
}
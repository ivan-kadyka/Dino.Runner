using System;
using Infra.Observable;

namespace App.Character.Dino
{
    public interface ICharacterBehaviorContext
    {
        IObservableValue<CharacterBehaviorType> CurrentType { get; }
        
        IObservable<TimeSpan> TimeLeft { get; }
    }
}
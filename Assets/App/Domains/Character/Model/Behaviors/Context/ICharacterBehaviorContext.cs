using System;
using Infra.Observable;

namespace App.Domains.Character.Model.Behaviors.Context
{
    public interface ICharacterBehaviorContext
    {
        IObservableValue<CharacterBehaviorType> CurrentType { get; }
        
        IObservable<TimeSpan> TimeLeft { get; }
    }
}
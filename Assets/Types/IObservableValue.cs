using System;

namespace Observables
{
    public interface IObservableValue<out TResult> : IObservable<TResult>
    {
        TResult Value { get; }
    }
}
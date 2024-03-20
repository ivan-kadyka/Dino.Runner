using System;

namespace Infra.Observable
{
    public interface IObservableValue<out TResult> : IObservable<TResult>
    {
        TResult Value { get; }
    }
}
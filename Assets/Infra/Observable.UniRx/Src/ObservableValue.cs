using System;
using UniRx;

namespace Infra.Observable.UniRx
{
    public class ObservableValue<T> : ISubject<T>, IDisposable, IOptimizedObservable<T>, IObservableValue<T>
    {
        public T Value => _behaviorSubject.Value;

        private readonly BehaviorSubject<T> _behaviorSubject;

        public ObservableValue(T defaultValue)
        {
            _behaviorSubject = new BehaviorSubject<T>(defaultValue);
        }
        
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _behaviorSubject.Subscribe(observer);
        }

        public void OnCompleted()
        {
            _behaviorSubject.OnCompleted();
        }

        public void OnError(Exception error)
        {
            _behaviorSubject.OnError(error);
        }

        public void OnNext(T value)
        {
            _behaviorSubject.OnNext(value);
        }

        public void Dispose()
        {
            _behaviorSubject.Dispose();
        }

        public bool IsRequiredSubscribeOnCurrentThread()
        {
            return _behaviorSubject.IsRequiredSubscribeOnCurrentThread();
        }
    }
}
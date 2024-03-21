using System;
using UniRx;

namespace App.GameCore
{
    internal class ColliderObjectsContext : IColliderObjectObservable, IColliderObjectObserver
    {
        private readonly Subject<IObject> _subject = new Subject<IObject>();
        
        public IDisposable Subscribe(IObserver<IObject> observer)
        {
            return _subject.Subscribe(observer);
        }

        public void OnCompleted()
        {
            _subject.OnCompleted();
        }

        public void OnError(Exception error)
        {
            _subject.OnError(error);
        }

        public void OnNext(IObject value)
        {
            _subject.OnNext(value);
        }
    }
}
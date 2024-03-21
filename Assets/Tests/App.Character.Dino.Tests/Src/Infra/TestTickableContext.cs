using System;
using Infra.Components.Tickable;
using UniRx;

namespace App.Character.Dino.Tests
{
    public class TestTickableContext : ITickableContext
    {
        public IObservable<float> Updated => _subject;

        private readonly Subject<float> _subject = new Subject<float>();

        public void ExecuteUpdate(float deltaTime)
        {
            _subject.OnNext(deltaTime);
        }
    }
}
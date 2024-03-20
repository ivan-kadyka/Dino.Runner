using System;
using UniRx;
using UnityEngine;

namespace Infra.Components.Tickable.UniRx
{
    public class TickableContext : MonoBehaviour, ITickableContext
    {
        public IObservable<float> Updated => _updateSubject;

        private readonly Subject<float> _updateSubject = new Subject<float>();
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _updateSubject.OnNext(Time.deltaTime);
        }
    }
}
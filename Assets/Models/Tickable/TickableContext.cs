using System;
using Models.Tickable;
using UniRx;
using UnityEngine;

namespace Models
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
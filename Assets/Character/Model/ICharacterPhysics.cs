using System;
using Models;
using Models.Tickable;
using UnityEngine;

namespace Character.Model
{
    public interface ICharacterPhysics : ITickableContext
    {
        IObservable<string> Collider { get; }
        
        bool IsGrounded { get; }
        
        Transform Transform { get; }

        void Move(Vector3 motion);
    }
}
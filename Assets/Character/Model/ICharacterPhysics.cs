using System;
using Types;
using UnityEngine;

namespace Character.Model
{
    public interface ICharacterPhysics
    {
        IObservable<Unit> Updated { get; }
        
        IObservable<string> Collider { get; }
        
        bool IsGrounded { get; }
        
        Transform Transform { get; }

        void Move(Vector3 motion);
    }
}
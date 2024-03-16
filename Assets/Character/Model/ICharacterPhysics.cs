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

        void Move(Vector3 motion);
    }
}
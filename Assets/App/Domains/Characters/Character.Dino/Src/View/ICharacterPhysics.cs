using System;
using Infra.Components.Tickable;
using UnityEngine;

namespace App.Character.Dino
{
    public interface ICharacterPhysics : ITickableContext
    {
        IObservable<string> Collider { get; }
        
        bool IsGrounded { get; }
        
        Transform Transform { get; }

        void Move(Vector3 motion);
    }
}
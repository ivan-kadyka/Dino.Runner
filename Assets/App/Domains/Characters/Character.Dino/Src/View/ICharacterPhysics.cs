using System;
using App.GameCore;
using Infra.Components.Tickable;
using UnityEngine;

namespace App.Character.Dino
{
    /// <summary>
    /// Defines an interface for character physics, extending ITickableContext to include physics-related properties and actions such as movement and collision detection.
    /// </summary>
    internal interface ICharacterPhysics : ITickableContext
    {
        /// <summary>
        /// An observable that emits the identifier of the collider the character interacts with.
        /// </summary>
        IObservable<IObject> Collider { get; }
    
        /// <summary>
        /// Indicates whether the character is currently grounded, i.e., standing on a surface.
        /// </summary>
        bool IsGrounded { get; }
    
        /// <summary>
        /// The Transform component of the character, representing its position, rotation, and scale in the game world.
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        /// Moves the character according to the specified motion vector.
        /// </summary>
        /// <param name="motion">The vector representing the direction and magnitude of the movement.</param>
        void Move(Vector3 motion);
    }

}
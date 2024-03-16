using UnityEngine;

namespace Character.Model
{
    public interface ICharacterPhysics
    {
        bool IsGrounded { get; }

        void Move(Vector3 motion);
    }
}
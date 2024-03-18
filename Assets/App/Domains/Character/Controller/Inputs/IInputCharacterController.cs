using System;

namespace Character.Controller.Inputs
{
    public interface IInputCharacterController
    {
        event Action JumpPressed;
    }
}
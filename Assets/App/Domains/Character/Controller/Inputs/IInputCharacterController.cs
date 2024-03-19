using System;
using Types;

namespace App.Domains.Character.Controller.Inputs
{
    public interface IInputCharacterController
    {
        IObservable<Unit> JumpPressed { get; }
    }
}
using System;
using UniRx;

namespace App.Character.Dino
{
    public interface IInputCharacterController
    {
        IObservable<Unit> JumpPressed { get; }
    }
}
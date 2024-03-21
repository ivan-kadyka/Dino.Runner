using System;
using UniRx;

namespace App.Character.Dino
{
    internal interface IInputCharacterController
    {
        IObservable<Unit> JumpPressed { get; }
    }
}
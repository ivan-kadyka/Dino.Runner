using System;
using Infra.Observable;
using Infra.Observable.Src;
using Types;

namespace App.Domains.Character.Controller.Inputs
{
    public interface IInputCharacterController
    {
        IObservable<Unit> JumpPressed { get; }
    }
}
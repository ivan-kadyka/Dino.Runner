using System;
using UniRx;

namespace App.Character.Dino
{
    /// <summary>
    /// Defines an interface for handling character control inputs
    /// </summary>
    //TODO: IInputCharacterController should extends IController
    internal interface IInputCharacterController
    {
        /// <summary>
        /// An observable that triggers when the jump action is initiated by the player.
        /// </summary>
        IObservable<Unit> JumpPressed { get; }
    }
}
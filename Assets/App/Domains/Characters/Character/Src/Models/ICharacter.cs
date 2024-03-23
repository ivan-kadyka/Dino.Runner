using System;
using System.Threading;
using App.GameCore;
using Cysharp.Threading.Tasks;

namespace App.Character
{
    /// <summary>
    /// Defines the behavior and properties of a character in the game, including actions like jump, run, and idle,
    /// and the ability to apply effects. It also integrates with the game's context for speed and character effect management.
    /// </summary>
    public interface ICharacter : IGameContext, ICharacterStateContext, IDisposable
    {
        /// <summary>
        /// Initiates a jump action for the character.
        /// </summary>
        /// <param name="token">A CancellationToken for cancelling the task if needed.</param>
        /// <returns>A UniTask that represents the asynchronous operation.</returns>
        UniTask Jump(CancellationToken token = default);

        /// <summary>
        /// Initiates a run action for the character.
        /// </summary>
        /// <param name="token">A CancellationToken for cancelling the task if needed.</param>
        /// <returns>A UniTask that represents the asynchronous operation.</returns>
        UniTask Run(CancellationToken token = default);
    
        /// <summary>
        /// Puts the character into an idle state.
        /// </summary>
        /// <param name="token">A CancellationToken for cancelling the task if needed.</param>
        /// <returns>A UniTask that represents the asynchronous operation.</returns>
        UniTask Idle(CancellationToken token = default);

        /// <summary>
        /// Applies an effect to the character based on the provided options.
        /// </summary>
        /// <param name="behavior">Character effect behavior</param>
        /// <param name="startOptions">The options defining the effect to apply.</param>
        /// <param name="token">A CancellationToken for cancelling the task if needed.</param>
        /// <returns>A UniTask that represents the asynchronous operation.</returns>
        UniTask ApplyEffectBehavior(ICharacterBehavior behavior, EffectStartOptions startOptions, CancellationToken token = default);
    }

}
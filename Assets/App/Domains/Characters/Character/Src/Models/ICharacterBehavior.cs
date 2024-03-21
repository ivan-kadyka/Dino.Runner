using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;

namespace App.Character
{
    /// <summary>
    /// Extends the ITickable interface to define behaviors specific to a character,
    /// including execution of behavior-specific actions and managing speed.
    /// </summary>
    public interface ICharacterBehavior : ITickable
    {
        /// <summary>
        /// Gets the speed associated with the character's current behavior.
        /// </summary>
        float Speed { get; }
    
        /// <summary>
        /// Executes the behavior's main action asynchronously.
        /// </summary>
        /// <param name="token">A CancellationToken for cancelling the task if needed.</param>
        /// <returns>A UniTask that represents the asynchronous operation of the behavior's execution.</returns>
        UniTask Execute(CancellationToken token = default);
    }
}
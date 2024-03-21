using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;

namespace App.Character.Dino
{
    /// <summary>
    /// Defines an interface for a jump behavior, extending ITickable to include functionality for executing the jump action asynchronously.
    /// </summary>
    internal interface IJumpBehavior : ITickable
    {
        /// <summary>
        /// Executes the jump action asynchronously.
        /// </summary>
        /// <param name="token">A CancellationToken for optionally cancelling the execution.</param>
        /// <returns>A UniTask representing the asynchronous operation of executing the jump.</returns>
        UniTask Execute(CancellationToken token = default);
    }

}
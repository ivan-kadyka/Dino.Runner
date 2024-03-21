using System.Threading;
using Cysharp.Threading.Tasks;
using Infra.Controllers;

namespace App.Spawner
{
    /// <summary>
    /// Extends the IController interface to define additional functionality for spawner controllers, including the ability to spawn objects asynchronously.
    /// </summary>
    public interface ISpawnerController : IController
    {
        /// <summary>
        /// Initiates the spawning of objects asynchronously.
        /// </summary>
        /// <param name="token">A CancellationToken for optionally cancelling the spawn operation.</param>
        /// <returns>A UniTask representing the asynchronous operation of spawning objects.</returns>
        UniTask Spawn(CancellationToken token = default);
    }

}
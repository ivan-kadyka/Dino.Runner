using System.Threading;
using Cysharp.Threading.Tasks;

namespace Infra.Controllers
{
    /// <summary>
    /// Provides extension methods for IController instances, enabling additional utility functions such as running a controller with automatic start and stop.
    /// </summary>
    public static class ControllerExt
    {
        /// <summary>
        /// Runs the specified controller by starting it, awaiting cancellation, and then stopping it. This method facilitates a controlled execution flow.
        /// </summary>
        /// <param name="controller">The controller to run.</param>
        /// <param name="token">A CancellationToken that can be used to cancel the start and stop operations.</param>
        /// <returns>A UniTask that completes when the controller has been started and then stopped.</returns>
        public static async UniTask Run(this IController controller, CancellationToken token = default)
        {
            await controller.Start(token);

            token.ThrowIfCancellationRequested();
        
            await controller.Stop(token);
        }
    }

}
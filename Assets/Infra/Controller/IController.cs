using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Controllers
{
    public interface IController : IDisposable
    {
        UniTask Start(CancellationToken token = default);

        UniTask Stop(CancellationToken token = default);
    }

    public static class ControllerExt
    {
        public static async UniTask Run(this IController controller, CancellationToken token = default)
        {
            await controller.Start(token);

            token.ThrowIfCancellationRequested();
            
            await controller.Stop(token);
        }
    }
    
}
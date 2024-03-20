using System.Threading;
using Cysharp.Threading.Tasks;

namespace Infra.Controllers
{
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
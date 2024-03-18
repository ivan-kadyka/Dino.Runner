using System.Threading;
using Controllers;
using Cysharp.Threading.Tasks;
using Types;
using UniRx;

namespace Infra.Controllers
{
    public abstract class ControllerBase : DisposableBase, IController
    {
        protected CompositeDisposable _disposable = new CompositeDisposable();
        
        public async UniTask Start(CancellationToken token = default)
        {
            await OnStarted(token);
        }

        protected virtual UniTask OnStarted(CancellationToken token = default)
        {
            return UniTask.CompletedTask;
        }

        public async UniTask Stop(CancellationToken token = default)
        {
            await OnStopped(token);
        }
        
        protected virtual UniTask OnStopped(CancellationToken token = default)
        {
            return UniTask.CompletedTask;
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposable.Dispose();
            }
        }
    }
}
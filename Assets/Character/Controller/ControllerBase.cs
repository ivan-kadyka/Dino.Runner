using System.Threading;
using Controllers;
using Cysharp.Threading.Tasks;

namespace Character.Controller
{
    public abstract class ControllerBase : IController
    {
        private bool _isDisposed;
        
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
        
        public void Dispose()
        {
            if (_isDisposed)
                return;

            OnDisposed(true);
            _isDisposed = true;
        }

        protected virtual void OnDisposed(bool disposing)
        {
        }
    }
}
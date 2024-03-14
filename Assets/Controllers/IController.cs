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
}
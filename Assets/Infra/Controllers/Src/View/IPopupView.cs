using System.Threading;
using Cysharp.Threading.Tasks;

namespace Infra.Controllers.View
{
    public interface IPopupView : IView
    {
        UniTask Show(CancellationToken token = default);
    }
}
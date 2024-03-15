using System.Threading;
using Cysharp.Threading.Tasks;

namespace Controllers
{
    public interface IPopupView : IView
    {
        UniTask Show(CancellationToken token = default);
    }
}
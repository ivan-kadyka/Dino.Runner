using System.Threading;
using Cysharp.Threading.Tasks;

namespace Infra.Controllers.View
{
    /// <summary>
    /// Extends the IView interface to define specific behavior for popup views, including asynchronous showing of the popup.
    /// </summary>
    public interface IPopupView : IView
    {
        /// <summary>
        /// Shows the popup view asynchronously.
        /// </summary>
        /// <param name="token">A CancellationToken for optionally cancelling the show operation.</param>
        /// <returns>A UniTask representing the asynchronous operation of showing the popup.</returns>
        UniTask Show(CancellationToken token = default);
    }

}
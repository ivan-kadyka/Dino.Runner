using App.GameCore;
using Infra.Controllers.View;

namespace App.Round
{
    public interface IRoundView : IView
    {
        void SetUp(IGameContext gameContext);
    }
}
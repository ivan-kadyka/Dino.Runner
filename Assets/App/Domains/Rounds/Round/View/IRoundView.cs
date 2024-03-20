using App.Models;
using Infra.Controllers;
using Infra.Controllers.View;

namespace Controllers.Round.View
{
    public interface IRoundView : IView
    {
        void SetUp(IGameContext gameContext);
    }
}
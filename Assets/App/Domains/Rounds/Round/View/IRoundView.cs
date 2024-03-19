using App.Models;

namespace Controllers.Round.View
{
    public interface IRoundView : IView
    {
        void SetUp(IGameContext gameContext);
    }
}
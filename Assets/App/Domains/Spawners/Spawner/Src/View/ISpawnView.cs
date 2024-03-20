using App.GameCore;
using Infra.Controllers.View;

namespace App.Spawner
{
    public interface ISpawnView : IView
    {
        bool IsActive { get; set; }

        void SetUp(IGameContext gameContext, string tagName);
    }
}
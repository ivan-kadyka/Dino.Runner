using App.Models;
using Controllers;

namespace App.Domains.Spawner.View
{
    public interface ISpawnView : IView
    {
        bool IsActive { get; set; }

        void SetUp(IGameContext gameContext);
    }
}
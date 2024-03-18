using App.Models;
using Controllers;

namespace App.Domains.Spawner
{
    public interface ISpawnView : IView
    {
        bool IsActive { get; set; }

        void SetUp(IGameContext gameContext);
    }
}
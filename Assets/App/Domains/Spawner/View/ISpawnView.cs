using App.Models;
using Controllers;
using Infra.Controllers;
using Infra.Controllers.View;

namespace App.Domains.Spawner.View
{
    public interface ISpawnView : IView
    {
        bool IsActive { get; set; }

        void SetUp(IGameContext gameContext, string tagName);
    }
}
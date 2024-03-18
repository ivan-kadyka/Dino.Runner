using App.Domains.Spawner.View;
using Controllers.Spawner.Obstacle.Model;

namespace App.Domains.Spawner.Coins.Factory
{
    public interface ICoinFactory : ISpawnFactory<SpawnOptions, ISpawnView>
    {
    }
}
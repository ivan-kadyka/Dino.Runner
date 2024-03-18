using App.Domains.Spawner;
using Zenject;

namespace Controllers.Spawner.Obstacle.Model
{
    public class SpawnOptions
    {
        public int Id { get;}

        public SpawnOptions(int id)
        {
            Id = id;
        }
    }

    public interface ISpawnFactory<in TOptions, out TView> 
        where TView : ISpawnView
        where TOptions: SpawnOptions
    {
        TView Create(TOptions options);
    }

    public interface IObstacleFactory : ISpawnFactory<SpawnOptions, ISpawnView>
    {
    }
    
}
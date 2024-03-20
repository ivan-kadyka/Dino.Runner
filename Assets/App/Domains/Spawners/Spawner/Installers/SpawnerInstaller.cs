using Infra.Components.Tickable;
using Infra.Controllers;
using Zenject;

namespace App.Spawner
{
    public class SpawnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IController>().WithId("CompositeSpawnerController")
                .FromMethod(it => new CompositeSpawnerController(
                    it.Container.Resolve<SpawnSettings>(),
                    it.Container.ResolveId<ISpawnerController>("ObstaclesController"),
                    it.Container.ResolveId<ISpawnerController>("CoinController"),
                    it.Container.Resolve<ITickableContext>()));

            Container.BindInstance(new SpawnSettings()).AsSingle();
        }
    }
}
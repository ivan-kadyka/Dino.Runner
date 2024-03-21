using App.GameCore;
using Zenject;

namespace App.Domains.GameCore.Installers
{
    internal class GameCoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ColliderObjectsContext>().AsSingle();
            Container.Bind<IColliderObjectObservable>()
                .FromMethod(it => it.Container.Resolve<ColliderObjectsContext>()).AsSingle();
            Container.Bind<IColliderObjectObserver>()
                .FromMethod(it => it.Container.Resolve<ColliderObjectsContext>()).AsSingle();
        }
    }
}
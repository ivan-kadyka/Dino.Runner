using Infra.Controllers;
using Zenject;

namespace App
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AppController>()
                .FromMethod(it => new AppController(
                    it.Container.ResolveId<IController>("TopPanelController"),
                    it.Container.ResolveId<IController>("RoundController"),
                    it.Container.ResolveId<IController>("RetryPopupController")
                ))
                .AsSingle();
        }
    } 
}





using App.Popups.Retry;
using Infra.Controllers;
using Infra.Controllers.View;
using UnityEngine;
using Zenject;

namespace App.Popups
{
    public class PopupsInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _retryPopupPrefab;
    
        [SerializeField]
        private GameObject _canvas;
        
        public override void InstallBindings()
        {
            // Retry popup
            Container.Bind<IPopupView>()
                .WithId("RetryPopupView")
                .To<RetryPopupView>()
                .FromComponentInNewPrefab(_retryPopupPrefab)
                .UnderTransform(_canvas.transform)
                .AsCached();
        
            Container.Bind<IController>().WithId("RetryPopupController")
                .FromMethod(it => new RetryPopupController(
                    it.Container.ResolveId<IPopupView>("RetryPopupView")
                )).AsCached();
        }
    }
}
using Infra.Controllers;
using UnityEngine;
using Zenject;

namespace App.TopPanel
{
    internal class TopPanelInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _topPanelPrefab;
    
        [SerializeField]
        private GameObject _canvas;
        
        public override void InstallBindings()
        {
            Container.Bind<ITopPanelView>()
                .To<TopPanelView>()
                .FromComponentInNewPrefab(_topPanelPrefab)
                .UnderTransform(_canvas.transform)
                .AsSingle();
        
            Container.Bind<IController>().WithId("TopPanelController").To<TopPanelController>()
                .AsSingle();
        }
    }
}
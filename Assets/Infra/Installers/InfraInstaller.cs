using Models;
using Models.Tickable;
using UnityEngine;
using Zenject;

namespace Infra.Installers
{
    public class InfraInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _tickableGameObject;
        
        public override void InstallBindings()
        {
            var tickableComponent = _tickableGameObject.GetComponent<TickableContext>();
            Container.Rebind<ITickableContext>().FromInstance(tickableComponent);
        }
    }
}
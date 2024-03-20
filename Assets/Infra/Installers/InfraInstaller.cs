using Infra.Components.Tickable;
using Infra.Components.Tickable.UniRx;
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
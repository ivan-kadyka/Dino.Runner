using System.Threading;
using Character.Controller;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AppContext
{
    public class AppController : ControllerBase
    {
        public AppController()
        {
        }

        protected override UniTask OnStarted(CancellationToken token = default)
        {
            Debug.Log("AppController: Started");
            
            return base.OnStarted(token);
        }
    }
}
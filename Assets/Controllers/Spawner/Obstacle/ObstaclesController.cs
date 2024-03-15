using System.Threading;
using Character.Controller;
using Cysharp.Threading.Tasks;

namespace Controllers.Spawner.Obstacle
{
    public class ObstaclesController : ControllerBase, IObstaclesController
    {
        public ObstaclesController()
        {
            
        }
        
        protected override UniTask OnStarted(CancellationToken token = default)
        {
            return base.OnStarted(token);
        }
    }
}
using System.Threading;
using Character.Controller;
using Character.Model;
using Cysharp.Threading.Tasks;
using Models.Tickable;
using UniRx;
using UnityEngine;

namespace Controllers.TopPanel
{
    public class TopPanelController : ControllerBase
    {
        private readonly ITopPanelView _view;
        private readonly ICharacterContext _characterContext;
        private readonly ITickableContext _tickableContext;

        private float _score;

        public TopPanelController(
            ITopPanelView view,
            ITickableContext tickableContext,
            ICharacterContext characterContext)
        {
            _view = view;
            _characterContext = characterContext;
            _disposable.Add(tickableContext.Updated.Subscribe(OnUpdated));
        }

        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _score = 0;
            UpdateHiScore();
            return base.OnStarted(token);
        }

        protected override UniTask OnStopped(CancellationToken token = default)
        {
            UpdateHiScore();
            return base.OnStopped(token);
        }

        private void OnUpdated(float deltaTime)
        {
            _score += _characterContext.Speed.Value * Time.deltaTime;
            _view.UpdateScore(Mathf.FloorToInt(_score));
        }
        
        private void UpdateHiScore()
        {
            int hiscore = PlayerPrefs.GetInt("hiScore", 0);

            if (_score > hiscore)
            {
                hiscore = Mathf.FloorToInt(_score);
                PlayerPrefs.SetInt("hiScore", hiscore);
            }
            
            _view.UpdateHiScore(Mathf.FloorToInt(hiscore));
        }
    }
}
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
        private readonly ICharacterSpeed _character;
        private readonly ITickableContext _tickableContext;

        private float _score;

        public TopPanelController(
            ITopPanelView view,
            ITickableContext tickableContext,
            ICharacterSpeed character)
        {
            _view = view;
            _character = character;
            _disposable.Add(tickableContext.Updated.Subscribe(OnUpdated));
        }

        protected override UniTask OnStarted(CancellationToken token = default)
        {
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
            _score += _character.Speed * Time.deltaTime;
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
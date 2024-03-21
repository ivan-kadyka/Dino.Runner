using System;
using System.Threading;
using App.Character;
using App.GameCore;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;
using Infra.Controllers.Base;
using UniRx;
using UnityEngine;

namespace App.TopPanel
{
    public class TopPanelController : ControllerBase
    {
        private readonly ITopPanelView _view;
        private readonly IGameContext _gameContext;
        private readonly ITickableContext _tickableContext;

        private float _score;

        public TopPanelController(
            ITopPanelView view,
            ITickableContext tickableContext,
            ICharacterStateContext characterStateContext,
            IGameContext gameContext)
        {
            _view = view;
            _gameContext = gameContext;
            _disposables.Add(tickableContext.Updated.Subscribe(OnUpdated));
            
            _disposables.Add(characterStateContext.State.Subscribe(OnBehaviorTypeChanged));
            _disposables.Add(characterStateContext.TimeLeft.Subscribe(OnTimeLeft));
        }

        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _score = 0;
            UpdateHiScore();
            _view.UpdateEffectType(CharacterState.Default);
            return base.OnStarted(token);
        }

        protected override UniTask OnStopped(CancellationToken token = default)
        {
            UpdateHiScore();
            return base.OnStopped(token);
        }

        private void OnBehaviorTypeChanged(CharacterState type)
        {
            _view.UpdateEffectType(type);
        }
        
        private void OnTimeLeft(TimeSpan timeLeft)
        {
            _view.UpdateEffectTime(timeLeft);
        }

        private void OnUpdated(float deltaTime)
        {
            _score += _gameContext.Speed * Time.deltaTime;
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
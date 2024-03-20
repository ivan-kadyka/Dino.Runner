using System;
using System.Threading;
using App.Domains.Character.Model;
using App.Domains.Character.Model.Behaviors.Context;
using App.Domains.GameCore.Src;
using App.Models;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;
using Infra.Controllers;
using UniRx;
using UnityEngine;

namespace Controllers.TopPanel
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
            ICharacterBehaviorContext characterBehaviorContext,
            IGameContext gameContext)
        {
            _view = view;
            _gameContext = gameContext;
            _disposables.Add(tickableContext.Updated.Subscribe(OnUpdated));
            
            _disposables.Add(characterBehaviorContext.CurrentType.Subscribe(OnBehaviorTypeChanged));
            _disposables.Add(characterBehaviorContext.TimeLeft.Subscribe(OnTimeLeft));
        }

        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _score = 0;
            UpdateHiScore();
            _view.UpdateEffectType(CharacterBehaviorType.Default);
            return base.OnStarted(token);
        }

        protected override UniTask OnStopped(CancellationToken token = default)
        {
            UpdateHiScore();
            return base.OnStopped(token);
        }

        private void OnBehaviorTypeChanged(CharacterBehaviorType type)
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
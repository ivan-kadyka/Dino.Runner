using System.Collections.Generic;
using System.Linq;
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
    internal class TopPanelController : ControllerBase
    {
        private readonly ITopPanelView _view;
        private readonly IGameContext _gameContext;
        private readonly ITickableContext _tickableContext;

        private float _score;

        public TopPanelController(
            ITopPanelView view,
            ITickableContext tickableContext,
            ICharacterEffectsContext characterEffectsContext,
            IGameContext gameContext)
        {
            _view = view;
            _gameContext = gameContext;
            _disposables.Add(tickableContext.Updated.Subscribe(OnUpdated));
            
            _disposables.Add(characterEffectsContext.Effects.Subscribe(OnEffectsChanged));
            _disposables.Add(characterEffectsContext.Updated.Subscribe(OnEffectUpdated));
        }

        protected override UniTask OnStarted(CancellationToken token = default)
        {
            _score = 0;
            UpdateHiScore();
            _view.UpdateEffectType(CharacterEffect.Default);
            return base.OnStarted(token);
        }

        protected override UniTask OnStopped(CancellationToken token = default)
        {
            UpdateHiScore();
            return base.OnStopped(token);
        }

        private void OnEffectsChanged(IReadOnlyCollection<CharacterEffect> effects)
        {
            if (effects.Count > 0)
                _view.UpdateEffectType(effects.First());
        }
        
        private void OnEffectUpdated(EffectUpdateOptions options)
        {
            _view.UpdateEffectTime(options.TimeLeft);
        }

        private void OnUpdated(float deltaTime)
        {
            _score += _gameContext.Speed * Time.deltaTime;
            _view.UpdateScore(Mathf.FloorToInt(_score));
        }
        
        private void UpdateHiScore()
        {
            //TODO: extract work with PlayerPrefs to IStorage
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
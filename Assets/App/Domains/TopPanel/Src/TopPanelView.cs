using System;
using App.Character;
using TMPro;
using UnityEngine;

namespace App.TopPanel
{
    internal class TopPanelView : MonoBehaviour, ITopPanelView
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;
         
        [SerializeField]
        private TextMeshProUGUI _hiScoreText;
        
        [SerializeField]
        private TextMeshProUGUI _effectNameText;
        
        [SerializeField]
        private GameObject _timePanel;
        
        [SerializeField]
        private TextMeshProUGUI _timeText;

        public void UpdateHiScore(int value)
        {
            _hiScoreText.text = value.ToString("D5");
        }

        public void UpdateScore(int value)
        {
            _scoreText.text = value.ToString("D5");
        }

        public void UpdateEffectType(CharacterState state)
        {
            if (state == CharacterState.Default || state == CharacterState.Idle)
            {
                _effectNameText.text = "None";
                _timePanel.SetActive(false);
            }
            else
            {
                _effectNameText.text = state.ToString();
                _timePanel.SetActive(true);
            }
        }

        public void UpdateEffectTime(TimeSpan timeLeft)
        {
            var seconds = Mathf.RoundToInt((float)timeLeft.TotalMilliseconds / 1000);
            _timeText.text = $"{seconds}s";
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
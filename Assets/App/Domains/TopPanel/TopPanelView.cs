using System;
using Character.Model;
using TMPro;
using UnityEngine;

namespace Controllers.TopPanel
{
    public class TopPanelView : MonoBehaviour, ITopPanelView
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

        public void UpdateEffect(CharacterEffectState effectState, TimeSpan timeLeft)
        {
            _timePanel.SetActive(effectState != CharacterEffectState.None);

            _effectNameText.text = effectState.ToString();
            _timeText.text = $"{timeLeft.Seconds}s";
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
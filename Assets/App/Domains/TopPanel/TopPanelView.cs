using System;
using App.Domains.Character.Model;
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

        public void UpdateEffect(CharacterBehaviorType behaviorType, TimeSpan timeLeft)
        {
            _timePanel.SetActive(behaviorType != CharacterBehaviorType.Default);

            _effectNameText.text = behaviorType.ToString();
            _timeText.text = $"{timeLeft.Seconds}s";
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
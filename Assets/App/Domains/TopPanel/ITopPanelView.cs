using System;
using App.Domains.Character.Model;
using Character.Model;

namespace Controllers.TopPanel
{
    public interface ITopPanelView : IView
    {
        void UpdateHiScore(int value);
        
        void UpdateScore(int value);

        void UpdateEffect(CharacterBehaviorType behaviorType, TimeSpan timeLeft);
    }
}
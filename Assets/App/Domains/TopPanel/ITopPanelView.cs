using System;
using App.Domains.Character.Model;
using Character.Model;

namespace Controllers.TopPanel
{
    public interface ITopPanelView : IView
    {
        void UpdateHiScore(int value);
        
        void UpdateScore(int value);

        void UpdateEffectType(CharacterBehaviorType behaviorType);
        
        void UpdateEffectTime(TimeSpan timeLeft);
    }
}
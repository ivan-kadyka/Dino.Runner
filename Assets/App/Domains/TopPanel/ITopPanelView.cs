using System;
using Character.Model;

namespace Controllers.TopPanel
{
    public interface ITopPanelView : IView
    {
        void UpdateHiScore(int value);
        
        void UpdateScore(int value);

        void UpdateEffect(CharacterEffectState effectState, TimeSpan timeLeft);
    }
}
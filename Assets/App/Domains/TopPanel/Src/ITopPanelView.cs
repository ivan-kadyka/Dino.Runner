using System;
using App.Character;
using Infra.Controllers.View;

namespace App.TopPanel
{
    public interface ITopPanelView : IView
    {
        void UpdateHiScore(int value);
        
        void UpdateScore(int value);

        void UpdateEffectType(CharacterState state);
        
        void UpdateEffectTime(TimeSpan timeLeft);
    }
}
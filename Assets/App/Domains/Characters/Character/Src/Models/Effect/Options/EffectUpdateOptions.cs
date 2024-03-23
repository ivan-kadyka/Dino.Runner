using System;

namespace App.Character
{
    public struct EffectUpdateOptions
    {
        public CharacterEffect Effect { get; }
        public TimeSpan TimeLeft { get; }

        public EffectUpdateOptions(CharacterEffect effect, TimeSpan timeLeft)
        {
            Effect = effect;
            TimeLeft = timeLeft;
        }
    }
}
using System;

namespace App.Character
{
    public struct EffectUpdateOptions
    {
        public CharacterState State { get; }
        public TimeSpan TimeLeft { get; }

        public EffectUpdateOptions(CharacterState state, TimeSpan timeLeft)
        {
            State = state;
            TimeLeft = timeLeft;
        }
    }
}
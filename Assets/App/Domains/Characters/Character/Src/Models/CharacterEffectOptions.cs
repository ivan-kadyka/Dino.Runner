using System;

namespace App.Character
{
    public class CharacterEffectOptions
    {
        public CharacterEffect Type { get; }
        
        public TimeSpan Duration { get; }

        public CharacterEffectOptions(CharacterEffect type, TimeSpan duration)
        {
            Type = type;
            Duration = duration;
        }
    }
}
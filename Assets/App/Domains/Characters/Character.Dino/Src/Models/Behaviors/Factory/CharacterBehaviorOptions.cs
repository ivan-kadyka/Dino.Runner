namespace App.Character.Dino
{
    internal class CharacterBehaviorOptions
    {
        public static readonly CharacterBehaviorOptions Default = new CharacterBehaviorOptions(CharacterEffect.Default, 0);
        public CharacterEffect Effect { get; }
        public float Speed { get; }

        public CharacterBehaviorOptions(CharacterEffect effect, float speed)
        {
            Effect = effect;
            Speed = speed;
        }
    }
}
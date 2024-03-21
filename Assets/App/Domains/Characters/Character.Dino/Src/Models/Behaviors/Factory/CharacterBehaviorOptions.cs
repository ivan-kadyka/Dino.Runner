namespace App.Character.Dino
{
    internal class CharacterBehaviorOptions
    {
        public static readonly CharacterBehaviorOptions Default = new CharacterBehaviorOptions(CharacterState.Default, 0);
        public CharacterState State { get; }
        public float Speed { get; }

        public CharacterBehaviorOptions(CharacterState state, float speed)
        {
            State = state;
            Speed = speed;
        }
    }
}
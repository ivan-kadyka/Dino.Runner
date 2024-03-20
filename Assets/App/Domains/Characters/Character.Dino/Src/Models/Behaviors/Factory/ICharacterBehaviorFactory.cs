namespace App.Character.Dino
{
    public interface ICharacterBehaviorFactory
    {
        ICharacterBehavior Create(CharacterBehaviorOptions options);
    }
}
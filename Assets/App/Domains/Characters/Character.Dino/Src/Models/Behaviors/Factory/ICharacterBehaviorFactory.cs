namespace App.Character.Dino
{
    internal interface ICharacterBehaviorFactory
    {
        ICharacterBehavior Create(CharacterBehaviorOptions options);
    }
}
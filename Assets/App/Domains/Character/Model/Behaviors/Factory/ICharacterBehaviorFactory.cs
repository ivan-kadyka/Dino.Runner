namespace App.Domains.Character.Model.Behaviors.Factory
{
    public interface ICharacterBehaviorFactory
    {
        ICharacterBehavior Create(CharacterBehaviorType type);
    }
}
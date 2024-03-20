namespace App.Character.Dino
{
    public interface IJumpBehaviorFactory
    {
        IJumpBehavior Create(JumpBehaviorType type);
    }
}
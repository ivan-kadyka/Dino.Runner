namespace App.Character.Dino
{
    internal interface IJumpBehaviorFactory
    {
        IJumpBehavior Create(JumpBehaviorType type);
    }
}
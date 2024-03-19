namespace App.Domains.Character.Model.Behaviors.Jump.Factory
{
    public interface IJumpBehaviorFactory
    {
        IJumpBehavior Create(JumpBehaviorType type);
    }
}
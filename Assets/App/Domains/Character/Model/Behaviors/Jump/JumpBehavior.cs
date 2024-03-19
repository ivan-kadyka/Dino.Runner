using System.Threading;
using Character.Model;
using Cysharp.Threading.Tasks;


namespace App.Domains.Character.Model.Behaviors.Jump
{
    public class JumpBehavior : JumpBaseBehavior
    {
        public JumpBehavior(ICharacterPhysics physics, CharacterSettings settings) : base(physics, settings)
        {
        }
        
        public override void Update(float deltaTime)
        {
            if (_physics.IsGrounded)
                return;
            
            base.Update(deltaTime);
        }

        public override UniTask Execute(CancellationToken token = default)
        {
            if (_physics.IsGrounded)
            {
                return base.Execute(token);
            }

            return UniTask.CompletedTask;
        }
    }
}
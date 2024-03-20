using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Character.Dino
{
    public class CharacterBehavior : ICharacterBehavior
    {
        public float Speed { get; }

        private readonly IJumpBehavior _jumpBehavior;
        
        public CharacterBehavior(IJumpBehavior jumpBehavior, float speed)
        {
            Speed = speed;
            _jumpBehavior = jumpBehavior;
        }
        
        public void Update(float deltaTime)
        {
            _jumpBehavior.Update(deltaTime);
        }

        public UniTask Execute(CancellationToken token = default)
        {
            return _jumpBehavior.Execute(token);
        }
    }
}
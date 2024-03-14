using Character.View;

namespace Character.Model
{
    public class Character : ICharacter
    {
        public int Speed { get; }
        
        public void Jump()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
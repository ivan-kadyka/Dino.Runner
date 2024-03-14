namespace Character.Model
{
    public interface ICharacter
    {
        int Speed { get; }

        void Jump();

        void Move();
    }
}
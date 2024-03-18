namespace Controllers.Spawner.Coins.View
{
    public interface ICoinView
    {
        bool IsActive { get; set; }

        void UpdateSpeed(float speed);
    }
}
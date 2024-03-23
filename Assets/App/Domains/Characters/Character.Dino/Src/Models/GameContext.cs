using App.GameCore;

namespace App.Character.Dino.GameContext
{
    internal class GameContext : IGameContext
    {
        public float Speed => _gameContext.Speed;
        
        private IGameContext _gameContext = new StubGameContext();

        public void Set(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }
    }

    internal class StubGameContext : IGameContext
    {
        public float Speed { get; } = 0;
    }
}
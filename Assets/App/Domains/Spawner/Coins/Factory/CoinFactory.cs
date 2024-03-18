using Controllers.Spawner.Coins.Factory;
using Controllers.Spawner.Coins.View;
using Controllers.Spawner.Obstacle.Factory;
using Zenject;

namespace App.Domains.Spawner.Coins.Factory
{
    public class CoinFactory : ICoinFactory
    {
        private readonly DiContainer _container;
        private readonly CoinsScriptableObject _coinsScriptableObject;

        public CoinFactory(DiContainer container, CoinsScriptableObject coinsScriptableObject)
        {
            _container = container;
            _coinsScriptableObject = coinsScriptableObject;
        }
        
        public ICoinView Create(CoinOptions param)
        {
            throw new System.NotImplementedException();
        }
    }
}
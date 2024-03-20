using App.GameCore;
using Zenject;

namespace App.Spawner.Coins
{
    public class CoinFactory : ICoinFactory
    {
        private readonly DiContainer _container;
        private readonly CoinsScriptableObject _coinsScriptableObject;
        private readonly IGameContext _gameContext;

        public CoinFactory(DiContainer container, CoinsScriptableObject coinsScriptableObject, IGameContext gameContext)
        {
            _container = container;
            _coinsScriptableObject = coinsScriptableObject;
            _gameContext = gameContext;
        }

        public ISpawnView Create(SpawnOptions options)
        {
            var coin = _coinsScriptableObject.Coins[options.Id];
            
            var view = _container.InstantiatePrefab(coin.Prefab).GetComponent<ISpawnView>();
            var objectName = GetObjectName(coin.CoinType);
            
            view.SetUp(_gameContext, objectName);

            return view;
        }
        
        private string GetObjectName(CoinType coinType)
        {
            return "Coin_" + coinType;
        }
    }
}
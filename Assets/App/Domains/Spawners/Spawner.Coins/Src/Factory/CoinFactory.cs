using App.GameCore;
using UnityEngine;
using Zenject;

namespace App.Spawner.Coins
{
    internal class CoinFactory : ICoinFactory
    {
        private readonly DiContainer _container;
        private readonly CoinsScriptableObject _coinsScriptableObject;
        private readonly Transform _parentTransform;
        private readonly IGameContext _gameContext;

        public CoinFactory(
            DiContainer container,
            CoinsScriptableObject coinsScriptableObject,
            Transform parentTransform,
            IGameContext gameContext)
        {
            _container = container;
            _coinsScriptableObject = coinsScriptableObject;
            _parentTransform = parentTransform;
            _gameContext = gameContext;
        }

        public ISpawnView Create(SpawnOptions options)
        {
            var coin = _coinsScriptableObject.Coins[options.Id];
            
            var view = _container.InstantiatePrefab(coin.Prefab, _parentTransform).GetComponent<ISpawnView>();
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
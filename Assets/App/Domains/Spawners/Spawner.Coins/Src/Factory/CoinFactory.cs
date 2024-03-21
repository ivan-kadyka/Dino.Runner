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
        private readonly IColliderObjectObserver _colliderObjectObserver;

        public CoinFactory(
            DiContainer container,
            CoinsScriptableObject coinsScriptableObject,
            Transform parentTransform,
            IGameContext gameContext,
            IColliderObjectObserver colliderObjectObserver)
        {
            _container = container;
            _coinsScriptableObject = coinsScriptableObject;
            _parentTransform = parentTransform;
            _gameContext = gameContext;
            _colliderObjectObserver = colliderObjectObserver;
        }

        public ISpawnView Create(SpawnOptions options)
        {
            var coin = _coinsScriptableObject.Coins[options.Id];
            
            var view = _container.InstantiatePrefab(coin.Prefab, _parentTransform).GetComponent<ISpawnView>();

            var coinObject = new GameCore.CoinObject(coin.CoinType);
            view.SetUp(_gameContext, _colliderObjectObserver, coinObject);

            return view;
        }
    }
}
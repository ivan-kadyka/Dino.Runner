using App.Domains.Spawner.View;
using App.Models;
using Controllers.Spawner.Obstacle.Factory;
using Controllers.Spawner.Obstacle.Model;
using Zenject;

namespace App.Domains.Spawner.Coins.Factory
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
            var spawnObject = _coinsScriptableObject.prefabs[options.Id];
            
            var view = _container.InstantiatePrefab(spawnObject).GetComponent<ISpawnView>();
            var colliderTag = GetColliderTag(options.Id);
            
            view.SetUp(_gameContext, colliderTag);

            return view;
        }

        //temp simplified converting
        private string GetColliderTag(int id)
        {
            CoinType type = (CoinType)id;

            return "Coin_" + type;
        }
    }
}
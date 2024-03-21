using System.Collections.Generic;

namespace App.Spawner.Coins.Settings
{
    internal class CoinsSettings : ICoinsSettings
    {
        public IReadOnlyDictionary<int, CoinType> Items { get; }

        public CoinsSettings(CoinsScriptableObject data)
        {
            var items = new Dictionary<int, CoinType>();

            for (int i = 0; i < data.Coins.Length; i++)
            {
                items[i] = data.Coins[i].CoinType;
            }

            Items = items;
        }
    }
}
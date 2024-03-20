using System.Collections.Generic;

namespace App.Spawner.Coins.Settings
{
    public interface ICoinsSettings
    {
        IReadOnlyDictionary<int, CoinType> Items { get; }
    }
}
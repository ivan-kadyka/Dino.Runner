using System.Collections.Generic;
using App.GameCore;

namespace App.Spawner.Coins.Settings
{
    /// <summary>
    /// Defines an interface for accessing coin settings, including a read-only dictionary that maps
    /// identifiers to their respective coin types.
    /// </summary>
    internal interface ICoinsSettings
    {
        /// <summary>
        /// Gets a read-only dictionary of coin identifiers mapped to their corresponding coin types.
        /// </summary>
        IReadOnlyDictionary<int, CoinType> Items { get; }
    }

}
using App.GameCore;
using UnityEngine;

namespace App.Spawner.Coins
{
    [CreateAssetMenu(fileName = "CoinsSO", menuName = "ScriptableObjects/CoinsScriptableObject", order = 1)]
    internal class CoinsScriptableObject : ScriptableObject
    {
        public CoinObject[] Coins;
    }
    
    [System.Serializable]
    internal struct CoinObject
    {
        public GameObject Prefab;
       
        public CoinType CoinType;
    }
}
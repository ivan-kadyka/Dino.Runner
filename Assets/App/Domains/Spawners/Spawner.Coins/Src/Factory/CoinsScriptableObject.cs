using UnityEngine;

namespace App.Spawner.Coins
{
    [CreateAssetMenu(fileName = "CoinsSO", menuName = "ScriptableObjects/CoinsScriptableObject", order = 1)]
    public class CoinsScriptableObject : ScriptableObject
    {
        public CoinObject[] Coins;
    }
    
    [System.Serializable]
    public struct CoinObject
    {
        public GameObject Prefab;
       
        public CoinType CoinType;
    }
}
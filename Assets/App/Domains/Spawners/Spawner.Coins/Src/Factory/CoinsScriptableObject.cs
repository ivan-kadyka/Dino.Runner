using UnityEngine;

namespace App.Spawner.Coins
{
    [CreateAssetMenu(fileName = "CoinsSO", menuName = "ScriptableObjects/CoinsScriptableObject", order = 1)]
    public class CoinsScriptableObject : ScriptableObject
    {
        public GameObject[] prefabs;
    }
}
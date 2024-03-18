using UnityEngine;

namespace Controllers.Spawner.Obstacle.Factory
{
    [CreateAssetMenu(fileName = "CoinsSO", menuName = "ScriptableObjects/CoinsScriptableObject", order = 1)]
    public class CoinsScriptableObject : ScriptableObject
    {
        public GameObject[] prefabs;
    }
}